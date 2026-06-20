using System.Collections.Concurrent;

namespace blog.Messaging
{
    public class PendingReplyStore
    {
        private readonly ConcurrentDictionary<string, object> _pending = new();

        public (string correlationId, Task<T> replyTask) Register<T>(TimeSpan timeout)
        {
            var correlationId = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<T>(
                TaskCreationOptions.RunContinuationsAsynchronously
            );

            _pending[correlationId] = tcs;

            _ = Task.Delay(timeout)
                .ContinueWith(_ =>
                {
                    if (_pending.TryRemove(correlationId, out var t))
                        ((TaskCompletionSource<T>)t).TrySetException(
                            new TimeoutException($"Reply timeout: {correlationId}")
                        );
                });

            return (correlationId, tcs.Task);
        }

        public void Complete<T>(string correlationId, T reply)
        {
            if (_pending.TryRemove(correlationId, out var tcs))
                ((TaskCompletionSource<T>)tcs).TrySetResult(reply);
        }

        public void CompleteWithError<T>(string correlationId, Exception ex)
        {
            if (_pending.TryRemove(correlationId, out var tcs))
                ((TaskCompletionSource<T>)tcs).TrySetException(ex);
        }
    }
}
