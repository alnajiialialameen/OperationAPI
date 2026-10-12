using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class HandlingAgentsCompanyRepository : GenericRepository<HandlingAgentsCompanyDomain, HandlingAgentsCompany> , IHandlingAgentsCompanyService
    {
        public HandlingAgentsCompanyRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<ListDomain>> getList()
        {
            return await Context.HandlingAgentsCompanies
                .Select(x => new ListDomain
                {
                    Id = x.Id,
                    Name = x.NameEn    /// ما محتا ج mapper 
                })
                .ToListAsync();
        }

      
    }
}
