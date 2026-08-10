using OperationAPI.Application.Models.IdentityModel;

namespace OperationAPI.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(string UserId);
        Task<bool> ResetPasswordAsync(string userId, string password);
    }
}
