using OperationAPI.Domain;

namespace OperationAPI.Application.Contracts.Services
{
    public interface IAirlineService : IGenericService<AirLineDomain>
    {
        Task<bool> IsUniqueObject(AirLineDomain model);
    }
}
