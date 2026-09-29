using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OperationAPI.Presistence.Repositories
{
    public class TowerDataRepository : GenericRepository<TowerDataDomain, TowerDatum>, ITowerDataService
    {
        public TowerDataRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<TowerDataDomain>> GetTodayFilghtLocal(int? AirlineId)
        {
            var today = DateTime.Today;
            var data = await this.Context.TowerData
                .Include(x => x.AirLine)
                .Include(x => x.AircraftReg)
              //.Where(x => x.Date == DateOnly.FromDateTime(Date))
            .Where(x => x.Date == DateOnly.FromDateTime(today) && x.AirLineId == AirlineId).ToListAsync();

            return Mapper.Map<List<TowerDataDomain>>(data);
        }
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
            return await Context.TowerData.AnyAsync(x => x.Id != model.Id && (x.AircraftRegId == model.AircraftRegId && x.Date == model.Date && x.FlightNoName == model.FlightNoName));
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
