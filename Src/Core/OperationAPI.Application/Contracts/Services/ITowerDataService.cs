using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.Services
{
   public interface ITowerDataService : IGenericService<TowerDataDomain>
    {
        Task<bool> IsUniqueObjectSetUp(InitialDataDomain model);
        Task<List<TowerDataDomain>> GetTowerDataByDate(DateOnly Date ,int? AirlineId , int? Status);
        //Task<TowerDataDomain> UpdateAsyncDeparture(TowerDataDomain model);
        Task<TowerDataDomain> CreateDepartureInitial(DepartureInitialDomain model);
        Task<TowerDataDomain> UpdateDepartureInitial(DepartureInitialDomain model);


    }
}
