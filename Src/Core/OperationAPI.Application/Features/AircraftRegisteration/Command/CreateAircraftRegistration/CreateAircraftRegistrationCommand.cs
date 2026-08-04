using MediatR;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration
{
   public class CreateAircraftRegistrationCommand :IRequest<AircraftRegistrationDomain>
    {
       public CreateAircraftRegistrationCommand(AircraftRegistrationDomain model) 
        { 
            this.model = model;
        }
        public AircraftRegistrationDomain model { get; set; }

    }
}
