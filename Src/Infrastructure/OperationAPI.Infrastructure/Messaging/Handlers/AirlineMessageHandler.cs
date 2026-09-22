using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Infrastructure.Messaging.Handlers;

namespace Infrastructure.Messaging.Handlers
{
    public class AirlineMessageHandler : MessageHandlerBase<AirLineDomain>
    {
        private readonly IAirlineService service;

        public AirlineMessageHandler(IAirlineService service)
        {
            this.service = service;
        }
        public override async Task HandleAsync(AirLineDomain message, bool? isUpdateOperation)
        {
            if (isUpdateOperation == true)
            {
               // update logic
               await service.UpdateAsync(message);
            }
            else
            {
                // Create logic
                await service.CreateAsync(message);
            }
        }
    }
}
