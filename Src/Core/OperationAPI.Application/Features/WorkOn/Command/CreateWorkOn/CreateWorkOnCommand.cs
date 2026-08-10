using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.CreateWorkOn
{
   public class CreateWorkOnCommand : IRequest<WorkOnDomain>
    {
        public CreateWorkOnCommand(WorkOnDomain model)
        {
            this.model = model;
        }

        public WorkOnDomain model { get; set; }
    }
}
