using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.Services
{
   public interface IAircraftRegistration : IGenericService<AircraftRegistrationDomain>
    {
        Task<bool> IsUniqueObject(AircraftRegistrationDomain model);
    }
}
