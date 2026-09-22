using OperationAPI.Infrastructure.Messaging.Interfaces;
using RabbitMQ.Client;

namespace OperationAPI.Infrastructure.Messaging.Services
{
    public class RabbitMqTopologyInitializer : IRabbitMqTopologyInitializer
    {
        private readonly IRabbitMqConnection _connection;
        private readonly IRabbitMqRoutingResolver _messageResolver;

        public RabbitMqTopologyInitializer(IRabbitMqConnection connection, IRabbitMqRoutingResolver messageResolver)
        {
            _connection = connection;
            _messageResolver = messageResolver;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            // Get all metadata
            var configurations = _messageResolver.GetAll();

            // Get connection
            var connection = await _connection.GetConnectionAsync();

            // Create channel
            await using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);

            // Loop through all metadata
            foreach (var configuration in configurations)
            {
                // Declare Exchange
                await channel.ExchangeDeclareAsync(exchange: configuration.ExchangeName,
                    type: ExchangeType.Direct, durable: true,cancellationToken: cancellationToken);

                // Declare Queue
                await channel.QueueDeclareAsync(queue: configuration.QueueName, durable: true,
                    exclusive: false, autoDelete: false, cancellationToken: cancellationToken);

                // Bind Queue to Exchange
                await channel.QueueBindAsync(queue: configuration.QueueName, exchange: configuration.ExchangeName,
                    routingKey: configuration.RoutingKey,cancellationToken: cancellationToken);
            }
        }
    }
}
