using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OperationAPI.Identity.DBContext;

public class MyIdentityDBContextFactory : IDesignTimeDbContextFactory<MyIdentityDBContext>
{
    private readonly IConfiguration configuration;

    public MyIdentityDBContextFactory(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public MyIdentityDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyIdentityDBContext>();
        optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")); // Use a design-time connection string
       
        return new MyIdentityDBContext(optionsBuilder.Options);
    }
}