namespace blog.Common.Helper.Key
{
    public static class MQNameKey
    {
        public static readonly string JudgeQueue = "judge.judge";
        public static readonly string JudgeReply = "judge.judge.reply";
        public static readonly string JudgeDeadExchange = "judge.dlx";
        public static readonly string JudgeDeadRouterKey = "judge.judge.dlq";
    }
}
