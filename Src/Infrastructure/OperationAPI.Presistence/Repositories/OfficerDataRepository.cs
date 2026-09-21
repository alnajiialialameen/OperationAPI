using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class OfficerDataRepository : GenericRepository<OfficerDataDomain, OfficerDatum>, IOfficerDataService
    {
        public OfficerDataRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> IsUniqueObject(DepartureServiceDomain model)
        {    
            if (model.Id == 0 || model.Id == null)
            {
                return await Context.OfficerData.AnyAsync(x => x.TowerDataId == model.TowerDataId);
            }
            return  await Context.OfficerData.AnyAsync(x => x.TowerDataId == model.TowerDataId && x.Id != model.Id);
        }

        public async Task<bool> IsUniqueObject(LandingServiceDomain model)
        {
            if (model.Id == 0 || model.Id == null)
            {
                return await Context.OfficerData.AnyAsync(x => x.TowerDataId == model.TowerDataId);
            }
            return await Context.OfficerData.AnyAsync(x => x.TowerDataId == model.TowerDataId && x.Id != model.Id);
        }
    }
}
