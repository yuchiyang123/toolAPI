using System.Text.Json;
using blog.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public abstract class RabbitMQConsumerBaseForSignalR<TRequest, TReply>(
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

            if (string.IsNullOrEmpty(correlationId) || string.IsNullOrEmpty(replyTo))
            {
                logger.LogError(
                    "[{Consumer}] Missing CorrelationId/ReplyTo, sending to DLQ. Queue={Queue}",
                    GetType().Name,
                    QueueName
                );
                await channel.BasicNackAsync(
                    ea.DeliveryTag,
                    multiple: false,
                    requeue: false,
                    stoppingToken
                );
                return;
            }

            TReply reply;
            try
            {
                var request =
                    JsonSerializer.Deserialize<TRequest>(ea.Body.Span)
                    ?? throw new JsonException("Message body deserialized to null");

                await using var scope = scopeFactory.CreateAsyncScope();
                reply = await HandleAsync(scope.ServiceProvider, request, stoppingToken);

                await channel.BasicAckAsync(ea.DeliveryTag, multiple: false, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "[{Consumer}] Consumer error. CorrelationId={CorrelationId}",
                    GetType().Name,
                    correlationId
                );
                await channel.BasicNackAsync(
                    ea.DeliveryTag,
                    multiple: false,
                    requeue: false,
                    stoppingToken
                );
                store.CompleteWithError<TReply>(correlationId, ex);
                return;
            }

            // 回寫 reply queue
            using var replyChannel = await connection.CreateChannelAsync(
                cancellationToken: stoppingToken
            );
            var replyProps = new BasicProperties { CorrelationId = correlationId };

            await replyChannel.BasicPublishAsync(
                exchange: "",
                routingKey: replyTo,
                mandatory: false,
                basicProperties: replyProps,
                body: JsonSerializer.SerializeToUtf8Bytes(reply),
                cancellationToken: stoppingToken
            );

            store.Complete(correlationId, reply);
        };

        await channel.BasicConsumeAsync(QueueName, autoAck: false, consumer, stoppingToken);
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    protected abstract Task<TReply> HandleAsync(
        IServiceProvider sp,
        TRequest request,
        CancellationToken ct
    );
}
