using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType
{
    public class UpdateAircraftTypeCommand:IRequest<AircraftTypeDomain>
    {
        public AircraftTypeDomain model { get; set; }

        public UpdateAircraftTypeCommand(AircraftTypeDomain model)
        {
            this.model = model;
        }
    }
}
