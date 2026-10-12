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
   public class FuelCompanyRepository : GenericRepository<FuelCompanyDomain, FuelCompany>, IFuelCompanyService
    {
        public FuelCompanyRepository(Entities context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<bool> IsUniqueObject(FuelCompanyDomain model)
        {
            return await Context.FuelCompanies.AnyAsync(x => x.Id != model.Id && x.NameEn == model.NameEn);
        }


        public async Task<List<ListDomain>> getList()
        {
            return await Context.FuelCompanies
                .Select(x => new ListDomain
                {
                    Id = x.Id,
                    Name = x.NameEn    /// ما محتا ج mapper 
                })
                .ToListAsync();
        }
    }
}
