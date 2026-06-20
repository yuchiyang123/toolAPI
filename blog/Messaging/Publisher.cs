using System.Text.Json;
using blog.Common.Helper.Key;
using RabbitMQ.Client;

namespace blog.Messaging
{
    public class Publisher(IConnection _connection, PendingReplyStore _store)
    {
        public async Task<ReponseDto> SendAsync<RequireDto, ReponseDto>(
            RequireDto request,
            TimeSpan timeout,
            string routerKey,
            string replyKey
        )
        {
            var (correlationId, replyTask) = _store.Register<ReponseDto>(timeout);

            using var channel = await _connection.CreateChannelAsync();

            var props = new BasicProperties
            {
                CorrelationId = correlationId,
                ReplyTo = replyKey,
                Persistent = true,
            };

            var body = JsonSerializer.SerializeToUtf8Bytes(request);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: routerKey,
                mandatory: false,
                basicProperties: props,
                body: body
            );

            return await replyTask;
        }
    }
}
