namespace OperationAPI.Infrastructure.Messaging.Configurations
{
    public class MessageConfiguration
    {
        public string HostName { get; set; } = null!;
        public Dictionary<string, RabbitMqMessageMetadata>? Messages { get; set; } = new();
    }
}
