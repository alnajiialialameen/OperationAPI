using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command.CreateAirLineAgent
{
   public class CreateAirLineAgentCommand : IRequest<AirLineAgentDomain>
    {
        public AirLineAgentDomain model { get; set; }

        public CreateAirLineAgentCommand(AirLineAgentDomain model)
        {
            this.model = model;
        }
    }
}
