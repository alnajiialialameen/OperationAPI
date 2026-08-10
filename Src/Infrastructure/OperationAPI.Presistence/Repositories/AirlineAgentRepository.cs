using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class AirlineAgentRepository : GenericRepository<AirLineAgentDomain, AirLineAgent>, IAirlineAgentService
    {
        public AirlineAgentRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<AirLineAgentDomain> getByUserId(string userId)
        {
            var data = await this.Context.AirLineAgents.FirstOrDefaultAsync(q=> q.UserId == userId);

            if(data != null)
            {
                return this.Mapper.Map<AirLineAgentDomain>(data);
            }

            return new AirLineAgentDomain();
        }
    }
}
