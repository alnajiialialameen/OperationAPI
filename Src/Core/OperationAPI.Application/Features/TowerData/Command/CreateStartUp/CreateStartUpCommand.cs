using MediatR;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Command.CreateTowerData
{
    

    public class CreateStartUpCommand : IRequest<TowerDataDomain>
    {
        public CreateStartUpCommand(InitialDataDomain model)
        {
            this.model = model;
        }
        public InitialDataDomain model { get; set; }

    }
}
