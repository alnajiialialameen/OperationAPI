using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.DeleteAircraftSize
{
 
    public record DeleteAircraftSizeCommand(int Id) : IRequest<bool>;

}
