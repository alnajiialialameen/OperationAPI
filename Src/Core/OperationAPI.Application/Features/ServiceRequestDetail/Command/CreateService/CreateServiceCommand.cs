using MediatR;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.CreatelService
{
   
    public class CreateServiceCommand : IRequest<ServiceRequestDetailDomain>
    {
        public CreateServiceCommand(ServiceRequestDetailDomain model)
        {
            this.model = model;
        }
        public ServiceRequestDetailDomain model { get; set; }
    }
}
