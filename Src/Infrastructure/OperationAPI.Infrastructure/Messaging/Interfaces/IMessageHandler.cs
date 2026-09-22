namespace OperationAPI.Infrastructure.Messaging.Interfaces
{
    public interface IMessageHandler
    {
        Task HandleAsync(object message, bool? isUpdateOperation);
    }

    public interface IMessageHandler<T> : IMessageHandler
    {
        Task HandleAsync(T message, bool? isUpdateOperation);
    }
}
