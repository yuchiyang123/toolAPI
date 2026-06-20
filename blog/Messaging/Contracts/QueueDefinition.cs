namespace blog.Messaging.Contracts
{
    public class QueueDefinition
    {
        public required string Exchange { get; init; }

        /// <summary>
        /// topic / direct / fanout
        /// </summary>
        public required string ExchangeType { get; init; }
        public required string QueueName { get; init; }
        public required string RoutingKey { get; init; }
        public string? DlxExchange { get; init; } // null = 不設 DLX
        public string? DlqName { get; init; }
        public int? MessageTtl { get; init; }
        public int? MaxLength { get; init; }
    }
}
