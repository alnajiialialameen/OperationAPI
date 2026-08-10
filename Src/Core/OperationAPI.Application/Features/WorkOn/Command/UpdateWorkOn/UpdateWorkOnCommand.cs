using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.UpdateWorkOn
{
   public class UpdateWorkOnCommand : IRequest<WorkOnDomain>
    {
        public UpdateWorkOnCommand(WorkOnDomain model)
        {
            this.model = model;
        }
        public WorkOnDomain model { get; set; }
    }
}
