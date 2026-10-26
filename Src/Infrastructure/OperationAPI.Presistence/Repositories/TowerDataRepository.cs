using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Models;
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

        //public async Task<List<TowerDataDomain>> GetTodayFilghtLocal(int? AirlineId)
        //{
        //    var today = DateOnly.FromDateTime(DateTime.Today);

        //    var data = await this.Context.TowerData
        //        .Include(x => x.AirLine)
        //        .Include(x => x.AircraftReg)
        //        .Where(x => x.Date == today && (!AirlineId.HasValue || x.AirLineId == AirlineId.Value))
        //        .ToListAsync();

        //    return Mapper.Map<List<TowerDataDomain>>(data);
        //}

        public async Task<List<TowerDataDomain>> GetTodayFilghtLocal(int? AirlineId)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            return await this.Context.TowerData
                .AsNoTracking()
                .Where(x => x.Date == today && (!AirlineId.HasValue || x.AirLineId == AirlineId.Value))
                .ProjectTo<TowerDataDomain>(Mapper.ConfigurationProvider)
                .ToListAsync();
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

        //   public async Task<List<TowerDataViewDomain>> GetFlightByStatus(
        //int? airlineId,
        //List<int> statuses)
        //   {
        //       var today = DateOnly.FromDateTime(DateTime.Today);

        //       var data = await Context.TowerData
        //           .AsNoTracking()

        //           .Include(x => x.AirLine)
        //           .Include(x => x.AircraftReg)

        //           .Include(x => x.AirportIdFromNavigation)
        //               .ThenInclude(x => x.Country)

        //           .Include(x => x.AirportIdToNavigation)
        //               .ThenInclude(x => x.Country)

        //           .Include(x => x.FlightNoNavigation)

        //           .Where(x =>
        //               x.Date == today &&
        //               x.AirLineId == airlineId &&
        //               x.Status.HasValue &&
        //               EF.Constant(statuses).Contains(x.Status.Value))

        //           .ToListAsync();

        //       return Mapper.Map<List<TowerDataViewDomain>>(data);
        //   }




        public async Task<List<TowerDataViewDomain>> GetFlightByStatus(
    int? airlineId,
    List<int> statuses)
        {
            //var today = DateOnly.FromDateTime(DateTime.Today);

            return await Context.TowerData
                .AsNoTracking()
                .Where(x =>
                    //x.Date == today &&
                    x.AirLineId == airlineId && x.FidsFlightId > 0 &&
                    x.Status.HasValue &&
                    EF.Constant(statuses).Contains(x.Status.Value))
                .ProjectTo<TowerDataViewDomain>(
                    Mapper.ConfigurationProvider)
                .ToListAsync();
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
            result.TowerData = Mapper.Map<TowerDataDomain>(towerData);

            return result;
        }

        public async Task<bool> setStatus(int? TowerDataId,int? status)
        {
            var towerData = await Context.TowerData.FindAsync(TowerDataId);
            towerData.Status = status;
            return true;
        }


        public Task<int> GetStatusOfficer(TowerDataDomain model)
        {
            if (model == null)
            {
                return Task.FromResult(0);
            }

            // 1. تم الهبوط والإقلاع معاً (يجب فحصها أولاً قبل الشروط الفردية)
            if (model.Ata != null && model.LandingDate != null && model.Atd != null && model.TakeOffDate != null)
            {
                return Task.FromResult(5); // أو الرقم المخصص لحالة الهبوط والإقلاع معاً في نظامك
            }

            // 2. تم الإقلاع فقط
            if (model.Atd != null && model.TakeOffDate != null)
            {
                return Task.FromResult(3);
            }

            // 3. تم الهبوط فقط
            if (model.Ata != null && model.LandingDate != null)
            {
                return Task.FromResult(4);
            }

            // 4. وجود بيانات التسجيل فقط مع فراغ بقية البيانات
            if (model.AircraftRegId > 0 && model.Ata == null && model.LandingDate == null && model.Atd == null && model.TakeOffDate == null)
            {
                return Task.FromResult(1);
            }

            // قيمة افتراضية في حال لم ينطبق أي شرط لتفادي خطأ عدم إرجاع قيمة
            return Task.FromResult(0);
        }

        //public async Task<List<DepartureInitialDomain>> GetFilghtLocalNotComplate(int? AirlineId)
        //{
        //    var data = await Context.TowerData
        //        .Include(x => x.AirLine)
        //        .Include(x => x.AircraftReg)
        //        .Where(x =>
        //            x.FidsFlightId != null &&
        //            x.FidsFlightId != 5 &&
        //            (!AirlineId.HasValue ||
        //             x.AirLineId == AirlineId.Value))
        //        .ToListAsync();

        //    return Mapper.Map<List<DepartureInitialDomain>>(data);
        //}


        public async Task<List<TowerDataViewDomain>> GetFilghtLocalNotComplate(
            int? AirlineId)
        {
            var data = await Context.TowerData
                .AsNoTracking()
                .Include(x => x.AirLine)
                .Include(x => x.AircraftReg)
                .Include(x => x.AirportIdFromNavigation)
                .Include(x => x.AirportIdToNavigation)
                .Where(x =>
                    x.FidsFlightId != null &&
                    x.Status != 5 &&
                    (!AirlineId.HasValue ||
                     x.AirLineId == AirlineId.Value))
                .ToListAsync();

            return Mapper.Map<List<TowerDataViewDomain>>(data);
        }

        //public async Task<bool> ConfirmedOfficer(int? towerDataId)
        //{
        //    var officerData = await Context.OfficerData
        //        .FirstOrDefaultAsync(x => x.TowerDataId == towerDataId);

        //    if (officerData == null)
        //        return false;

        //    officerData.IsOfficerConfirmed = true;

        //    await Context.SaveChangesAsync();

        //    return true;
        //}


        public async Task<bool> ConfirmedOfficer(int? towerDataId)
        {
            var towerData = await Context.TowerData
                .FirstOrDefaultAsync(x => x.Id == towerDataId);

            if (towerData == null)
                return false;

            towerData.IsOfficerConfirmed = true;

            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TowerDataViewDomain>> GetSearchFilght(FlightSearchRequestModel model)
        {
            // 1. الاستعلام الأساسي مع العلاقات وفلترة FidsFlightId
            var query = Context.TowerData
                .AsNoTracking()
                .Include(x => x.AirLine)
                .Include(x => x.AircraftReg)
                .Include(x => x.AirportIdFromNavigation)
                .Include(x => x.AirportIdToNavigation)
                .Where(x => x.FidsFlightId != null && x.Status==5);

            // 2. فلترة شركة الطيران
            if (model.AirlineId.HasValue)
            {
                query = query.Where(x => x.AirLineId == model.AirlineId.Value);
            }

            // 3. فلترة رقم الرحلة (FlightNoName)
            if (!string.IsNullOrWhiteSpace(model.FlightNo))
            {
                query = query.Where(x => x.FlightNoName == model.FlightNo.Trim());
            }

            // 4. فلترة تاريخ البداية
            if (model.DateFrom.HasValue)
            {
                query = query.Where(x => x.Date >= model.DateFrom.Value);
            }

            // 5. فلترة تاريخ النهاية
            if (model.DateTo.HasValue)
            {
                query = query.Where(x => x.Date <= model.DateTo.Value);
            }

            // 6. جلب البيانات المطابقة فقط وتحويلها إلى Domain Model
            var data = await query.ToListAsync();

            return Mapper.Map<List<TowerDataViewDomain>>(data);
        }

        public async Task<bool> IsServiceRequestNotAccepted(int? towerDataId)
        {
            if (towerDataId == null)
                return false;

            // يفحص مباشرة إذا كان هناك تفاصيل طلب مرتبطة بـ TowerDataId ولم يتم قبولها بعد
            return await Context.ServiceRequestDetails
                .AnyAsync(x => x.ServiceRequest.TowerDataId == towerDataId && x.AcceptedBy == null);
        }

        public async Task<bool> IsServiceRequestAccepted(int? towerDataId)
        {
            if (towerDataId == null)
                return false;

            return await Context.ServiceRequestDetails
                .AnyAsync(x => x.ServiceRequest.TowerDataId == towerDataId && x.AcceptedBy != null);
        }
    }
}
