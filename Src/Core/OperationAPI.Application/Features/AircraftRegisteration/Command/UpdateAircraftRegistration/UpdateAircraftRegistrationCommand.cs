using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration
{
   public class UpdateAircraftRegistrationCommand : IRequest<AircraftRegistrationDomain>
    {
        public UpdateAircraftRegistrationCommand(AircraftRegistrationDomain model) 
        { 
            this.model = model;
        }

        public AircraftRegistrationDomain model { get; set; }
    }
}
