using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OperationAPI.Identity.DBContext;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence
{
    public static class PersistenceServicesRegisteration
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<Entities>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // use same transaction for different dbContext===> main dbContext(Entities) and IdentityDbContext(MyIdentityDBContext)
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // نفس Connection سيتم استخدامها بواسطة الـ DbContexts
            services.AddScoped(_ =>
            {
                return new SqlConnection(connectionString);
            });

            // Application DbContext
            services.AddDbContext<Entities>((serviceProvider, options) =>
            {
                var connection = serviceProvider.GetRequiredService<SqlConnection>();

                options.UseSqlServer(connection);
            });

            // Identity DbContext
            services.AddDbContext<MyIdentityDBContext>((serviceProvider, options) =>
            {
                var connection = serviceProvider.GetRequiredService<SqlConnection>();

                options.UseSqlServer(connection);
            });

            return services;
        }
    }
}
