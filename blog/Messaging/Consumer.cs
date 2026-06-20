// 泛型基底 Consumer
using System.Text.Json;
using blog.Common.Helper.Key;
using blog.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public abstract class RabbitMQConsumerBase<TRequest, TReply>(
    IConnection connection,
    PendingReplyStore store,
    IServiceScopeFactory scopeFactory,
    ILogger logger
) : BackgroundService
{
    protected abstract string QueueName { get; }
    protected abstract string DeadExchange { get; }
    protected abstract string DeadRouterKey { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken = default)
    {
        using var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

        var args = new Dictionary<string, object?>
        {
            ["x-dead-letter-exchange"] = DeadExchange,
            ["x-dead-letter-routing-key"] = DeadRouterKey,
        };

        await channel.ExchangeDeclareAsync(
            DeadExchange,
            ExchangeType.Direct,
            durable: true,
            cancellationToken: stoppingToken
        );
        await channel.QueueDeclareAsync(
            DeadRouterKey,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: args,
            cancellationToken: stoppingToken
        );
        await channel.QueueBindAsync(
            DeadRouterKey,
            DeadExchange,
            routingKey: DeadRouterKey,
            cancellationToken: stoppingToken
        );

        await channel.QueueDeclareAsync(
            QueueName,
            durable: true,
            exclusive: false,
            arguments: args,
            autoDelete: false,
            cancellationToken: stoppingToken
        );
        await channel.BasicQosAsync(
            0,
            prefetchCount: 5,
            global: false,
            cancellationToken: stoppingToken
        );

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            var correlationId = ea.BasicProperties.CorrelationId;
            var replyTo = ea.BasicProperties.ReplyTo;

            TReply reply;

            try
            {
                var request = JsonSerializer.Deserialize<TRequest>(ea.Body.ToArray())!;

                await using var scope = scopeFactory.CreateAsyncScope();

                // 子類別從 scope 拿自己要的 service
                var result = await HandleAsync(scope.ServiceProvider, request, stoppingToken);

                reply = result;

                await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Consumer error. CorrelationId={CorrelationId}", correlationId);
                await channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: false);
                store.CompleteWithError<TReply>(correlationId, ex);
                return;
            }

            // 回寫 reply queue
            using var replyChannel = await connection.CreateChannelAsync();
            var replyProps = new BasicProperties { CorrelationId = correlationId };

            await replyChannel.BasicPublishAsync(
                exchange: "",
                routingKey: replyTo,
                mandatory: false,
                basicProperties: replyProps,
                body: JsonSerializer.SerializeToUtf8Bytes(reply)
            );

            store.Complete(correlationId, reply);
        };

        await channel.BasicConsumeAsync(QueueName, autoAck: false, consumer);
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    protected abstract Task<TReply> HandleAsync(
        IServiceProvider sp,
        TRequest request,
        CancellationToken ct
    );
}
