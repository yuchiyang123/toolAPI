using System.Text.Json;
using blog.Dtos.MQ;
using blog.Hubs;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public abstract class RabbitMQConsumerBase<TRequest, TReply>(
    IConnection connection,
    IHubContext<MqHub> hub,
    IServiceScopeFactory scopeFactory,
    ILogger logger
) : BackgroundService
    where TRequest : IMQ
{
    protected abstract string QueueName { get; }
    protected abstract string DeadExchange { get; }
    protected abstract string DeadRouterKey { get; }
    protected abstract string SignalRRouterKey { get; }
    protected abstract string SignalRTopic { get; }

    private static readonly JsonSerializerOptions ReplyJsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    protected override async Task ExecuteAsync(CancellationToken stoppingToken = default)
    {
        logger.LogInformation(
            "[{Consumer}] ExecuteAsync START, queue={Queue}",
            GetType().Name,
            QueueName
        );
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

            TRequest request;
            TReply reply;
            try
            {
                request =
                    JsonSerializer.Deserialize<TRequest>(ea.Body.Span)
                    ?? throw new JsonException("Message body deserialized to null");

                await using var scope = scopeFactory.CreateAsyncScope();
                reply = await HandleAsync(scope.ServiceProvider, request, stoppingToken);

                await channel.BasicAckAsync(ea.DeliveryTag, multiple: false, stoppingToken);
            }
            catch (Exception ex)
            {
                // 壞訊息或處理失敗：不 requeue，交給 DLQ，避免卡住 prefetch
                logger.LogError(
                    ex,
                    "[{Consumer}] Consumer error. Queue={Queue} CorrelationId={CorrelationId}",
                    GetType().Name,
                    QueueName,
                    correlationId
                );
                await channel.BasicNackAsync(
                    ea.DeliveryTag,
                    multiple: false,
                    requeue: false,
                    stoppingToken
                );
                return;
            }

            var jsonString = JsonSerializer.Serialize(reply, ReplyJsonOptions);
            await hub
                .Clients.Client(request.ConnectId)
                .SendAsync(SignalRRouterKey, SignalRTopic, jsonString, stoppingToken);
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
