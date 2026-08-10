using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationAPI.Identity.Models;

namespace OperationAPI.Identity.Configurations
{
    public class UserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = IdentityIDsData.AdminRoleId,
                    UserId = IdentityIDsData.AdminUserId
                },
                new IdentityUserRole<string>
                {
                    RoleId = IdentityIDsData.TeacherRoleId,
                    UserId = IdentityIDsData.TeacherUserId
                },
                new IdentityUserRole<string>
                {
                    RoleId = IdentityIDsData.StudentRoleId,
                    UserId = IdentityIDsData.StudentUserId
                });

        }
    }
}
