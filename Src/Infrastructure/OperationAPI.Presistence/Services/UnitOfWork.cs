using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain.Common;
using OperationAPI.Identity.DBContext;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Entities context;
        private readonly MyIdentityDBContext identityContext;
        private IDbContextTransaction transaction;

        public UnitOfWork(Entities context, MyIdentityDBContext identityContext)
        {
            this.context = context;
            this.identityContext = identityContext;
        }

        public async Task BeginTransactionAsync()
        {
            transaction = await context.Database.BeginTransactionAsync();

            await identityContext.Database.UseTransactionAsync(transaction.GetDbTransaction());
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
            await identityContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
