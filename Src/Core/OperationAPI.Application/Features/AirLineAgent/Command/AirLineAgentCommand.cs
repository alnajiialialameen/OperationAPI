using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command
{
   public class AirLineAgentCommand : IRequest<AirLineAgentDomain>
    {
        public AirLineAgentDomain model { get; set; }

        public AirLineAgentCommand(AirLineAgentDomain model)
        {
            this.model = model;
        }
    }
}
