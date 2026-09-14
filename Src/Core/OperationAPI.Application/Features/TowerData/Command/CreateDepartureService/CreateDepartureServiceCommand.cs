using MediatR;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Command.CreateDepartureService
{
    
    public class CreateDepartureServiceCommand : IRequest<OfficerDataDomain>
    {
        public CreateDepartureServiceCommand(DepartureServiceDomain model)
        {
            this.model = model;
        }
        public DepartureServiceDomain model { get; set; }
    }
}
