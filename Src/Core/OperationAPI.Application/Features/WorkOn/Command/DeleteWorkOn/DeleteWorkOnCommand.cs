using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.WorkOn.Command.DeleteWorkOn
{
    public record DeleteWorkOnCommand(int Id) : IRequest<bool>;
  
}
