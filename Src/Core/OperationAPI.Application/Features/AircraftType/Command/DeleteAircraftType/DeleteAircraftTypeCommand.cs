using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.DeleteAircraftType
{
    public record DeleteAircraftTypeCommand(int Id):IRequest<bool>
    {
    }
}
