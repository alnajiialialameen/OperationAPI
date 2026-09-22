using OperationAPI.Infrastructure.Messaging.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Microsoft.Extensions.DependencyInjection;
using OperationAPI.Infrastructure.Messaging.Configurations;
using System.Text.Json;
using System.Text;
using OperationAPI.Domain;

namespace OperationAPI.Infrastructure.Messaging.Services
{
    public class RabbitMqMessageConsumer : IRabbitMqMessageConsumer
    {
        private readonly IRabbitMqConnection _connection;
        private readonly IRabbitMqRoutingResolver _routingResolver;
        private readonly IServiceScopeFactory scopeFactory;

        public RabbitMqMessageConsumer(IRabbitMqConnection connection, IRabbitMqRoutingResolver routingResolver, IServiceScopeFactory scopeFactory)
        {
            _connection = connection;
            _routingResolver = routingResolver;
            this.scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var connection = await _connection.GetConnectionAsync();

            var channel = await connection.CreateChannelAsync();

            var messages = _routingResolver.GetAll();

            foreach (var metadata in messages)
            {
                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += async (sender, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    using var scope = scopeFactory.CreateScope();

                    var handlerResolver = scope.ServiceProvider.GetRequiredService<IMessageHandlerResolver>();

                    var wrapperType = typeof(RabbitMqMessage<>).MakeGenericType(metadata.MessageType);

                    var rabbitMessage = (IRabbitMqMessage?)JsonSerializer.Deserialize(message, wrapperType);

                    if (rabbitMessage == null)
                    {
                        throw new Exception("Failed to deserialize RabbitMQ message.");
                    }

                    var actualMessageType = rabbitMessage.Message.GetType();

                    if (actualMessageType != metadata.MessageType)
                    {
                        await channel.BasicNackAsync(args.DeliveryTag, multiple: false, requeue: true);

                        return;
                    }

                    var handler = handlerResolver.Resolve(metadata.MessageType);

                    await handler.HandleAsync(rabbitMessage.Message, rabbitMessage.IsUpdateOperation);

                    await channel.BasicAckAsync(args.DeliveryTag, multiple: false);
                    
                };

                await channel.BasicConsumeAsync(queue: metadata.QueueName, autoAck: false, consumer: consumer);
            }
        
        }
    }

}
