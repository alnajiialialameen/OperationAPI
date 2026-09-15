using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.Services
{
  public interface IOfficerDataService : IGenericService<OfficerDataDomain>
    {
        Task<bool> IsUniqueObject(DepartureServiceDomain model);
        Task<bool> IsUniqueObject(LandingServiceDomain model);
    }
}
