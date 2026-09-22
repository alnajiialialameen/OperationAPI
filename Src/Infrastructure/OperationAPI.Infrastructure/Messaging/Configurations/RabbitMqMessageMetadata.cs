namespace OperationAPI.Infrastructure.Messaging.Configurations
{
    public class RabbitMqMessageMetadata
    {
        public string QueueName { get; set; } = null!;
        public string ExchangeName { get; set; } = null!;
        public string MessageTypeName { get; set; } = default!;
        public string RoutingKey { get; set; } = "";

        public Type MessageType => Type.GetType(MessageTypeName)?? throw new InvalidOperationException($"Cannot resolve type: {MessageTypeName}");
    }
}
