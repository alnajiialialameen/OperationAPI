using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.ConfirmAgent
{
   
    public class ConfirmAgentCommand : IRequest<ServiceRequestDetailDomain>
    {
        public ConfirmAgentCommand(confirmServiceDetailDomain model)
        {
            this.model = model;
        }
        public confirmServiceDetailDomain model { get; set; }
    }
}
