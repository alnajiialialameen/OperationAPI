using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationAPI.Identity.Models;

namespace OperationAPI.Identity.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = IdentityIDsData.StudentRoleId,
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp =  "0",
                    
                },
                new IdentityRole
                {
                    Id = IdentityIDsData.TeacherRoleId,
                    Name = "Teacher",
                    NormalizedName = "TEACHER",
                    ConcurrencyStamp = "0",
                },
                new IdentityRole
                {
                    Id = IdentityIDsData.AdminRoleId,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "0",
                });
        }
    }
}
