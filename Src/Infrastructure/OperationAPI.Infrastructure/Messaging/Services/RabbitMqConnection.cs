using OperationAPI.Infrastructure.Messaging.Configurations;
using OperationAPI.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace OperationAPI.Infrastructure.Messaging.Services
{
    public class RabbitMqConnection : IRabbitMqConnection
    {
        private readonly ConnectionFactory _factory;
        private readonly IOptions<MessageConfiguration> options;
        private IConnection? _connection;

        public RabbitMqConnection(IOptions<MessageConfiguration> options)
        {
            _factory = new ConnectionFactory
            {
                HostName = options.Value.HostName
            };
            this.options = options;
        }

        public async Task<IConnection> GetConnectionAsync()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = await _factory.CreateConnectionAsync();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.IsOpen)
                    _connection.CloseAsync().GetAwaiter().GetResult();

                _connection.Dispose();
            }
        }
    }
}
