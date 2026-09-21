namespace OperationAPI.Infrastructure.Messaging.Interfaces
{
    public interface IRabbitMqMessageConsumer
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}
