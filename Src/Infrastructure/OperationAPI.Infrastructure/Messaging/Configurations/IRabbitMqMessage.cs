namespace OperationAPI.Infrastructure.Messaging.Configurations
{
    public interface IRabbitMqMessage
    {
        object Message { get; }
        bool? IsUpdateOperation { get; }
    }
}
