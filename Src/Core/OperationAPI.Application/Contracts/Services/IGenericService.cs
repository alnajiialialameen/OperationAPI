using OperationAPI.Domain.Common;

namespace OperationAPI.Application.Contracts.Services
{
   public interface IGenericService<T> where T : BaseDomain 
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id, bool withTracking = false);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
