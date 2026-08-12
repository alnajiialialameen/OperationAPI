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
    public class CountryRepository : GenericRepository<CountryDomain, Country>,ICountryService
    {
        public CountryRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }


        public async Task<bool> IsUniqueObject(CountryDomain model)
        {
            return await Context.Countries.AnyAsync(x =>
              
                    x.Code == model.Code &&
                    x.NameAr == model.NameAr &&
                    x.NameEn!.ToLower() == model.NameEn!.ToLower()
                
            );
        }
    }
}
