namespace OperationAPI.Infrastructure.Messaging.Configurations
{
    public class RabbitMqMessage<T> : IRabbitMqMessage
    {
        public T Message { get; set; } = default!;

        public bool? IsUpdateOperation { get; set; }

        object IRabbitMqMessage.Message => Message!;
    }
}
