using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.ServiceRequestDetail.Command.UpdateService
{
   
    public class UpdateServiceCommand : IRequest<ServiceRequestDetailDomain>
    {
        public UpdateServiceCommand(ServiceRequestDetailDomain model)
        {
            this.model = model;
        }
        public ServiceRequestDetailDomain model { get; set; }
    }

}
