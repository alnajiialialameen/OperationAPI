using OperationAPI.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace OperationAPI.Infrastructure.Messaging.Handlers
{
    public class MessageHandlerResolver : IMessageHandlerResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public MessageHandlerResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public IMessageHandler Resolve(Type messageType)
        {
            var handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType);
            return (IMessageHandler)_serviceProvider.GetRequiredService(handlerType);
        }
    }

}
