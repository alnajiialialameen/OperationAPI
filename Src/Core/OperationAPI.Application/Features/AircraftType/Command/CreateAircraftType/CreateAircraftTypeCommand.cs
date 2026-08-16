using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftType.Command.CreateAircraftType
{
    public class CreateAircraftTypeCommand :IRequest<AircraftTypeDomain>
    {
        public CreateAircraftTypeCommand(AircraftTypeDomain model)
        {
            this.model = model;
        }
        public AircraftTypeDomain model { get; set; }
    }
}
