namespace OperationAPI.Infrastructure.Messaging.Interfaces
{
    public interface IMessageHandlerResolver
    {
        IMessageHandler Resolve(Type messageType);
    }
}
