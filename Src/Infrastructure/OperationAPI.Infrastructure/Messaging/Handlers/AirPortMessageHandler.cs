using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;

namespace OperationAPI.Infrastructure.Messaging.Handlers
{
    public class AirPortMessageHandler : MessageHandlerBase<AirPortDomain>
    {
        private readonly IAirportService service;

        public AirPortMessageHandler(IAirportService service)
        {
            this.service = service;
        }
        public override async Task HandleAsync(AirPortDomain message, bool? isUpdateOperation)
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
