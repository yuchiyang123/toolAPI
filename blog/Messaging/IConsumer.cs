namespace blog.Messaging
{
    public interface IMessageHandler<TRequest, TReply>
    {
        Task<TReply> HandleAsync(TRequest request, CancellationToken ct);
    }
}
