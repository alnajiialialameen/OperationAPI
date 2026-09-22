using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class AircraftTypeRepository : GenericRepository<AircraftTypeDomain, AircraftType>, IAircraftTypeService
    {
        public AircraftTypeRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> IsUniqueObject(AircraftTypeDomain model)
        {
            return await Context.AircraftTypes.AnyAsync(x => x.Id != model.Id && x.Type == model.Type);
        }
    }
}
