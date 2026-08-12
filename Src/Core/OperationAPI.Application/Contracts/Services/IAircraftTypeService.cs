using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.Services
{
    public interface IAircraftTypeService:IGenericService<AircraftTypeDomain>
    {
        Task<bool> IsUniqueObject(AircraftTypeDomain model);

    }
}
