using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.CreateAircraftSize
{
    public class CreateAircraftSizeCommand : IRequest<AircraftSizeDomain>
    {
        public CreateAircraftSizeCommand(AircraftSizeDomain modal)
        {
            this.modal = modal;
        }
        public AircraftSizeDomain modal { get; set; }
    }
}
