using RabbitMQ.Client;

namespace OperationAPI.Infrastructure.Messaging.Interfaces
{
    public interface IRabbitMqConnection : IDisposable
    {
        Task<IConnection> GetConnectionAsync();    
    }
}
