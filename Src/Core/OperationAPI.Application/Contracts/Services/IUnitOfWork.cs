using OperationAPI.Domain.Common;

namespace OperationAPI.Application.Contracts.Services
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(); // start transaction
        Task CommitAsync(); // commit transaction
        Task RollbackAsync(); // rollback transaction
        Task<int> SaveChangesAsync(); // save changes to the database
    }
}
