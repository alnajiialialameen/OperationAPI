using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftSize.Command.UpdateAircraftSize
{
   

    public class UpdateAircraftSizeCommand : IRequest<AircraftSizeDomain>
    {
        public UpdateAircraftSizeCommand(AircraftSizeDomain model)
        {
            this.model = model;
        }

        public AircraftSizeDomain model { get; set; }
    }


}
