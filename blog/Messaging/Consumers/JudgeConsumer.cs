using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using blog.Hubs;
using blog.Services;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

namespace blog.Messaging.Consumers
{
    public class JudgeConsumer(
        IConnection connection,
        IHubContext<MqHub> hub,
        IServiceScopeFactory scopeFactory,
        ILogger<JudgeConsumer> logger
    )
        : RabbitMQConsumerBase<JudgeRequestDto, SubmissionResponse>(
            connection,
            hub,
            scopeFactory,
            logger
        )
    {
        protected override string QueueName => MQNameKey.JudgeQueue;
        protected override string DeadExchange => MQNameKey.JudgeDeadExchange;
        protected override string DeadRouterKey => MQNameKey.JudgeDeadRouterKey;
        protected override string SignalRRouterKey => SignalREnums.MqMessage.ToString();
        protected override string SignalRTopic => SignalRTopicEnums.Judge.ToString();

        protected override async Task<SubmissionResponse> HandleAsync(
            IServiceProvider sp,
            JudgeRequestDto request,
            CancellationToken ct
        )
        {
            var judgeService = sp.GetRequiredService<JudgeService>();
            return await judgeService.GetJudgeResultById(request, ct);
        }
    }
}
