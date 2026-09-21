using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class AircraftSizeRepository : GenericRepository<AircraftSizeDomain, AircraftSize>, IAircraftSizeService
    {
        public AircraftSizeRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> IsUniqueObject(AircraftSizeDomain model)
        {
            return await Context.AircraftSizes.AnyAsync(x => x.Id != model.Id && x.Size == model.Size);
        }

    }
}
