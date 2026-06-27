using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using blog.Hubs;
using blog.Services;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;

namespace blog.Messaging.Consumers
{
    public class JudgeTestConsumer(
        IConnection connection,
        IHubContext<MqHub> hub,
        IServiceScopeFactory scopeFactory,
        ILogger<JudgeTestConsumer> logger
    )
        : RabbitMQConsumerBase<JudgeTestRequestDto, SubmissionResponse>(
            connection,
            hub,
            scopeFactory,
            logger
        )
    {
        protected override string QueueName => MQNameKey.JudgeTestQueue;
        protected override string DeadExchange => MQNameKey.JudgeDeadExchange;
        protected override string DeadRouterKey => MQNameKey.JudgeTestDeadRouterKey;
        protected override string SignalRRouterKey => SignalREnums.MqMessage.ToString();
        protected override string SignalRTopic => SignalRTopicEnums.JudgeTest.ToString();

        protected override async Task<SubmissionResponse> HandleAsync(
            IServiceProvider sp,
            JudgeTestRequestDto request,
            CancellationToken ct
        )
        {
            var judgeService = sp.GetRequiredService<JudgeService>();
            return await judgeService.GetJudgeTestResultById(request, ct);
        }
    }
}
