using MediatR;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Command.CreateLandingService
{
   
    public class CreateLandingServiceCommand : IRequest<OfficerDataDomain>
    {
        public CreateLandingServiceCommand(LandingServiceDomain model)
        {
            this.model = model;
        }
        public LandingServiceDomain model { get; set; }
    }
}
