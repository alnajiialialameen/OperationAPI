using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command.UpdateAirLineAgent
{
   

    public class UpdateAirLineAgentCommand : IRequest<AirLineAgentDomain>
    {
        public AirLineAgentDomain model { get; set; }

        public UpdateAirLineAgentCommand(AirLineAgentDomain model)
        {
            this.model = model;
        }
    }
}
