using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;
using System.Linq;
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

        //public async Task<List<TowerDataDomain>> GetFlightByStatus(int? airlineId, List<int> statuses)
        //{
        //    var today = DateTime.Today;
        //    var data = await Context.TowerData
        //        .Include(x => x.AirLine)
        //        .Include(x => x.AircraftReg)
        //        .Include(x => x.AirportIdFromNavigation).ThenInclude(x => x.Country)
        //        .Include(x => x.AirportIdToNavigation).ThenInclude(x => x.Country)
        //        //.Include(x => x.CompanyInfo)
        //        .Include(x => x.FlightNoNavigation)
        //        //.Include(x => x.TripType)
        //        //.Include(x => x.OfficerData)

        //        .Where(x => x.Date == DateOnly.FromDateTime(today) &&
        //            x.AirLineId == airlineId
        //            //x.Status.HasValue &&
        //            //statuses.Contains(x.Status.Value)
        //            )
        //        .ToListAsync();

        //    return Mapper.Map<List<TowerDataDomain>>(data);
        //}

        public async Task<List<TowerDataViewDomain>> GetFlightByStatus(
      int? airlineId,
      List<int> statuses)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var data = await Context.TowerData
                .Include(x => x.AirLine)
                .Include(x => x.AircraftReg)
                .Include(x => x.AirportIdFromNavigation)
                    .ThenInclude(x => x.Country)
                .Include(x => x.AirportIdToNavigation)
                    .ThenInclude(x => x.Country)
                .Include(x => x.FlightNoNavigation)
                .Where(x =>
                    x.Date == today &&
                    x.AirLineId == airlineId &&
                    x.Status.HasValue &&
                    EF.Constant(statuses).Contains(x.Status.Value))
                .ToListAsync();

            return Mapper.Map<List<TowerDataViewDomain>>(data);
        }

        public async Task<OfficerDataDomain?> GetOfficerDataById(int? towerDataId)
        {
            if (towerDataId == null)
                return null;

            var towerData = await Context.TowerData
                .FirstOrDefaultAsync(x => x.Id == towerDataId);

            if (towerData == null)
                return null;

            var officerData = await Context.OfficerData
                .FirstOrDefaultAsync(x => x.TowerDataId == towerDataId);

            var result = officerData != null
                ? Mapper.Map<OfficerDataDomain>(officerData)
                : new OfficerDataDomain();

            result.TowerDataId = towerData.Id;
            result.TowerData = Mapper.Map<TowerDataFullDomain>(towerData);

            return result;
        }
    }
}
