using MediatR;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Command.CreateDepartureInitial
{
   

    public class UpdateDepartureFlightCommand : IRequest<TowerDataDomain>
    {
        public UpdateDepartureFlightCommand(DepartureInitialDomain model)
        {
            this.model = model;
        }
        public DepartureInitialDomain model { get; set; }
    }
}
