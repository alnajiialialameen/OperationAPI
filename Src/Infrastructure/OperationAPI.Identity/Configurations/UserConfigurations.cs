using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationAPI.Identity.Models;

namespace OperationAPI.Identity.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = IdentityIDsData.AdminUserId,
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FullName = "System",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    EmailConfirmed = true,
                    LockoutEnd = DateTimeOffset.Parse("2025-10-7"),
                    
                },
                new ApplicationUser
                {
                    Id = IdentityIDsData.TeacherUserId,
                    Email = "teacher@localhost.com",
                    NormalizedEmail = "TEACHER@LOCALHOST.COM",
                    FullName = "General",
                    UserName = "teacher@localhost.com",
                    NormalizedUserName = "TEACHER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Teacher@123"),
                    EmailConfirmed = true,
                    LockoutEnd = DateTimeOffset.Parse("2025-10-7"),
                },
                new ApplicationUser
                {
                    Id = IdentityIDsData.StudentUserId,
                    Email = "student@localhost.com",
                    NormalizedEmail = "STUDENT@LOCALHOST.COM",
                    FullName = "General",
                    UserName = "student@localhost.com",
                    NormalizedUserName = "STUDENT@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Student@123"),
                    EmailConfirmed = true,
                    LockoutEnd = DateTimeOffset.Parse("2025-10-7"),
                }
            );
        }
    }
}
