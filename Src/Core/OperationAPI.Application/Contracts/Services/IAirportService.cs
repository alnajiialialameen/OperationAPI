using OperationAPI.Domain;

namespace OperationAPI.Application.Contracts.Services
{
    public interface IAirportService : IGenericService<AirPortDomain>
    {
        Task<bool> IsUniqueObject(AirPortDomain model);
    }
}
