using System.Text.Json;
using Azure.Core;
using blog.Common.Helper.Key;
using blog.Dtos.MQ;
using blog.Hubs;
using blog.Messaging;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            var request = JsonSerializer.Deserialize<TRequest>(ea.Body.ToArray())!;
            try
            {
                await using var scope = scopeFactory.CreateAsyncScope();
                var result = await HandleAsync(scope.ServiceProvider, request, stoppingToken);
                reply = result;

                await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Consumer error. CorrelationId={CorrelationId}", correlationId);
                await channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: false);
                return;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
            };
            var jsonString = System.Text.Json.JsonSerializer.Serialize(reply, options);

            await hub
                .Clients.Client(request.ConnectId)
                .SendAsync(SignalRRouterKey, SignalRTopic, jsonString);
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
