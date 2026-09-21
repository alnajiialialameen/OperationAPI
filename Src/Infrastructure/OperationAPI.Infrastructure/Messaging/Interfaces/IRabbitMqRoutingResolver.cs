using OperationAPI.Infrastructure.Messaging.Configurations;

namespace OperationAPI.Infrastructure.Messaging.Interfaces
{
    public interface IRabbitMqRoutingResolver
    {
        RabbitMqMessageMetadata Resolve(Type messageType);
        IEnumerable<RabbitMqMessageMetadata> GetAll();
    }
}
