using blog.Common.Enum;
using Microsoft.AspNetCore.SignalR;

namespace blog.Hubs
{
    public class MqHub : Hub
    {
        public async Task SendToUserByConnectId(
            MQEnums routerKey,
            SignalRTopicEnums topic,
            string connectId,
            string message
        )
        {
            await Clients.Client(connectId).SendAsync(routerKey.ToString(), topic, message);
        }

        public async Task SendToUserByJudge(string connectId, string message)
        {
            await SendToUserByConnectId(MQEnums.Judge, SignalRTopicEnums.Judge, connectId, message);
        }
    }
}
