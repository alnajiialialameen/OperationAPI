using OperationAPI.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace OperationAPI.Identity.DBContext
{
    public class MyIdentityDBContext : IdentityDbContext<ApplicationUser>
    {
        public MyIdentityDBContext(DbContextOptions<MyIdentityDBContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // تعيين الـ Schema الافتراضية
            builder.HasDefaultSchema("Identity");

            // تطبيق الإعدادات من الملفات الأخرى
            builder.ApplyConfigurationsFromAssembly(
                typeof(MyIdentityDBContext).Assembly);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }

}
