namespace OperationAPI.Infrastructure.Messaging.Interfaces
{
    public interface IRabbitMqTopologyInitializer
    {
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
