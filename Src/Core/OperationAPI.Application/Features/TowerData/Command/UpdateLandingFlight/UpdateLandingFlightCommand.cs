using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.UpdateTakeOffFlight
{
   
    public class UpdateLandingFlightCommand : IRequest<TowerDataDomain>
    {
        public UpdateLandingFlightCommand(LandingInitialDomain model)
        {
            this.model = model;
        }
        public LandingInitialDomain model { get; set; }
    }
}
