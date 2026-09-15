using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Presistence.Repositories
{
    public class TowerDataRepository : GenericRepository<TowerDataDomain, TowerDatum>, ITowerDataService
    {
        public TowerDataRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

      

        //public async Task<List<TowerDataDomain>> GetTowerDataByDate(DateTime Date)
        //{
        //    var data = await this.Context.TowerData
        //        .Include(x => x.AirLine)
        //        .Include(x => x.AircraftReg)
        //        .Where(x => x.Date == DateOnly.FromDateTime(Date))
        //        .ToListAsync();

        //    return Mapper.Map<List<TowerDataDomain>>(data);
        //}
        public async Task<List<TowerDataDomain>> GetTowerDataByDate(DateOnly date, int? airlineId, int? status)
        {
            var data = await this.Context.TowerData
                .Include(x => x.AirLine)
                .Include(x => x.AircraftReg)
                .Where(x => x.Date == date && x.AirLineId == airlineId)
                .ToListAsync();

            return Mapper.Map<List<TowerDataDomain>>(data);
        }
        public async Task<bool> IsUniqueObjectSetUp(InitialDataDomain model)
        {
            return await Context.TowerData.AnyAsync(x => x.Id != model.Id && (x.AircraftRegId == model.AircraftRegId && x.Date == model.Date && x.FlightNo == model.FlightNo));


        }
        public Task<TowerDataDomain> CreateDepartureInitial(DepartureInitialDomain model)
        {
            throw new NotImplementedException();
        }

        public Task<TowerDataDomain> UpdateDepartureInitial(DepartureInitialDomain model)
        {
            throw new NotImplementedException();
        }

       
    }
}
