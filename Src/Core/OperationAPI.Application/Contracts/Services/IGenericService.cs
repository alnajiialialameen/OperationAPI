using OperationAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Contracts.Services
{
   public interface IGenericService<T> where T : BaseDomain 
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id, bool withTracking = true);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
