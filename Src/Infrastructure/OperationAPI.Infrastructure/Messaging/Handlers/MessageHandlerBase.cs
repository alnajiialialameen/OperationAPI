using OperationAPI.Infrastructure.Messaging.Interfaces;

namespace OperationAPI.Infrastructure.Messaging.Handlers
{
    public abstract class MessageHandlerBase<T> : IMessageHandler<T>
    {
        public abstract Task HandleAsync(T message, bool? isUpdateOperation);

        async Task IMessageHandler.HandleAsync(object message, bool? isUpdateOperation)
        {
            await HandleAsync((T)message, isUpdateOperation);
        }
    }
}
