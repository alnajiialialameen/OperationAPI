
using OperationAPI.Domain;

namespace OperationAPI.Application.Contracts.Services
{
    public interface IAirlineAgentService : IGenericService<AirLineAgentDomain>
    {
        Task<AirLineAgentDomain> getByUserId(string userId);
        Task<bool> IsUniqueObject(AirLineAgentDomain model);

        Task<List<AirLineAgentDomain>> GetAirLineAgentByAirlineId(int? AirlineId);


        public Task<List<ListDomain>> getList();

    }
}
