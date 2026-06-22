using RabbitMQ.Client;

namespace blog.Messaging.Infrastructure
{
    public class RabbitMQConnectionSignalR(IConnectionFactory factory) : IDisposable
    {
        private IConnection? _connection;
        private readonly SemaphoreSlim _lock = new(1, 1);
        private bool _disposed;

        public async Task<IConnection> GetConnectionAsync()
        {
            await _lock.WaitAsync();
            try
            {
                if (_connection is { IsOpen: true })
                    return _connection;

                _connection?.Dispose();
                _connection = await Task.Run(() => factory.CreateConnectionAsync());
                return _connection;
            }
            finally
            {
                _lock.Release();
            }
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            _disposed = true;
            _connection?.Dispose();
        }
    }
}
