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
  public class WorkOnRepository : GenericRepository<WorkOnDomain, WorkOn>, IWorkOnService
    {
        public WorkOnRepository(Entities context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<bool> IsUniqueObject(WorkOnDomain model)
        {
            return await Context.WorkOns.AnyAsync(x => x.Id != model.Id && x.UserId == model.UserId);


        }

     
    }
}
