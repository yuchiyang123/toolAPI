using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using blog.Services;
using RabbitMQ.Client;

namespace blog.Messaging.Consumers
{
    public class JudgeConsumer(
        IConnection connection,
        PendingReplyStore store,
        IServiceScopeFactory scopeFactory,
        ILogger<JudgeConsumer> logger
    )
        : RabbitMQConsumerBase<JudgeRequestDto, SubmissionResponse>(
            connection,
            store,
            scopeFactory,
            logger
        )
    {
        protected override string QueueName => MQNameKey.JudgeQueue;
        protected override string DeadExchange => MQNameKey.JudgeQueue;
        protected override string DeadRouterKey => MQNameKey.JudgeQueue;

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
