using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.AcceptOfficer
{


    public class AcceptOfficerCommand : IRequest<ServiceRequestDetailDomain>
    {
        public AcceptOfficerCommand(confirmServiceDetailDomain model)
        {
            this.model = model;
        }
        public confirmServiceDetailDomain model { get; set; }
    }
   
}
