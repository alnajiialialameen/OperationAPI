using OperationAPI.Infrastructure.Messaging.Configurations;
using OperationAPI.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Options;

namespace OperationAPI.Infrastructure.Messaging.Services
{
    public class RabbitMqMessageResolver : IRabbitMqRoutingResolver
    {
        private readonly MessageConfiguration _options;

        public RabbitMqMessageResolver(IOptions<MessageConfiguration> options)
        {
            this._options = options.Value;
        }

        public RabbitMqMessageMetadata Resolve(Type messageType)
        {
            var key = messageType.Name;
            if (!_options.Messages!.TryGetValue(key, out var config))
            {
                throw new Exception($"No RabbitMQ configuration found for {messageType.Name}");
            }

            return config;
        }

        public IEnumerable<RabbitMqMessageMetadata> GetAll()
        {
            return _options.Messages!.Values.ToList().AsReadOnly();
        }

    }
}
