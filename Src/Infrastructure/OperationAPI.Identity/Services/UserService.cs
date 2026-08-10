using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Identity;
using OperationAPI.Application.Models.IdentityModel;
using OperationAPI.Identity.Models;

namespace OperationAPI.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _userManager.Users.ToListAsync();

            List<Employee> data = new List<Employee>();

            foreach (var user in employees)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                data.Add(new Employee
                {
                    Id = user.Id,
                    Email = user.Email!,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    Roles = userRoles.ToList()
                });
            }

            return data;
        }
        public async Task<Employee> GetEmployee(string UserId)
        {
            var Student = await _userManager.FindByIdAsync(UserId);

            var userRoles = await _userManager.GetRolesAsync(Student!);

            return new Employee()
            {
                Email = Student!.Email!,
                FullName = Student.FullName,
                //LastName = Student.LastName,
                UserName = Student.UserName,
                PhoneNumber = Student.PhoneNumber,
                Id = Student.Id,
                Roles = userRoles.ToList()
            };
        }

        public async Task<bool> ResetPasswordAsync(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            var token = await  _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, password);

            return result.Succeeded;
        }
    }
}
