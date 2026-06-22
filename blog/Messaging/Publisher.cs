using System.Text.Json;
using System.Threading.Channels;
using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace blog.Messaging
{
    public class Publisher(
        IConnection _connection,
        IHubContext<MqHub> _hub,
        PendingReplyStore _store
    )
    {
        public async Task SandForSignalRAsync<RequireDto, ReponseDto>(
            RequireDto request,
            TimeSpan timeout,
            string routerKey,
            string replyKey,
            string connectId,
            SignalREnums signalRKey,
            SignalRTopicEnums signalTopic
        )
        {
            var (correlationId, replyTask) = _store.Register<ReponseDto>(timeout);

            await ProcessChannelAsync(request, routerKey, replyKey, correlationId);

            var data = await replyTask;
            var dataJsonString = JsonConvert.SerializeObject(data);

            await _hub
                .Clients.Client(connectId)
                .SendAsync(signalRKey.ToString(), signalTopic, dataJsonString);
        }

        public async Task<ReponseDto> SendAsync<RequireDto, ReponseDto>(
            RequireDto request,
            TimeSpan timeout,
            string routerKey,
            string replyKey
        )
        {
            var (correlationId, replyTask) = _store.Register<ReponseDto>(timeout);

            await ProcessChannelAsync(request, routerKey, replyKey, correlationId);

            return await replyTask;
        }

        private async Task ProcessChannelAsync<RequireDto>(
            RequireDto request,
            string routerKey,
            string replyKey,
            string? correlationId
        )
        {
            using var channel = await _connection.CreateChannelAsync();

            var props = new BasicProperties
            {
                CorrelationId = correlationId,
                ReplyTo = replyKey,
                Persistent = true,
            };

            var body = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(request);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: routerKey,
                mandatory: false,
                basicProperties: props,
                body: body
            );
        }

        public async Task PublishAsync<TRequireDto>(TRequireDto request, string routerKey)
        {
            using var channel = await _connection.CreateChannelAsync();
            var props = new BasicProperties { Persistent = true };
            var body = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(request);
            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: routerKey,
                mandatory: false,
                basicProperties: props,
                body: body
            );
        }
    }
}
