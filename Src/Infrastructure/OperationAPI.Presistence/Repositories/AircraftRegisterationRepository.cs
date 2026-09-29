using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
  public class AircraftRegisterationRepository : GenericRepository<AircraftRegistrationDomain, AircraftRegistration>, IAircraftRegistrationService
    {
        public AircraftRegisterationRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<AircraftRegistrationDomain>> GetRegistrationByAirlineId(int? AirlineId)
        {
            var data = await Context.AircraftRegistrations
                .Where(x => x.AireLineId == AirlineId)
                .ToListAsync();

            var result = Mapper.Map<List<AircraftRegistrationDomain>>(data);
            return result;
        }
        public async Task<bool> IsUniqueObject(AircraftRegistrationDomain model)
        {
            return await Context.AircraftRegistrations.AnyAsync(x => x.Id != model.Id && x.Registration == model.Registration);
        }
    }
}
