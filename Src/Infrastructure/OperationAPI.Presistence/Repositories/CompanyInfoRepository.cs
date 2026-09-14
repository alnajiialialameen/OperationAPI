using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class CompanyInfoRepository : GenericRepository<CompanyInfoDomain, CompanyInfo>, ICompanyInfoSercice
    {
        public CompanyInfoRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<bool> IsActive(CompanyInfoDomain model)
        {
            throw new NotImplementedException();
        }
        public override async Task<List<CompanyInfoDomain>> GetAsync()
        {
            var data = await base.Context.CompanyInfos.AsNoTracking()
                            .ToListAsync();

            var res = Mapper.Map<List<CompanyInfoDomain>>(data);

            return res;
        }

        public override async Task<CompanyInfoDomain> GetByIdAsync(int id, bool withTracking = false)
        {
            var query = base.Context.CompanyInfos.AsQueryable();

            if (!withTracking)
            {
                query = query.AsNoTracking();
            }

            var data = await query.FirstOrDefaultAsync(x => x.Id == id);

            var res = Mapper.Map<CompanyInfoDomain>(data);

            return res;
        }
    }
}
