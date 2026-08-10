using OperationAPI.Application.Models.IdentityModel;

namespace OperationAPI.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Loging(AuthRequest request);
        Task<RegisterationResponse> Register(RegisterationRequest request);
        Task<EditUserRequest> Edit(EditUserRequest request);
        Task<AuthResponse> VerifyEmail(string userId, string token);
        Task<List<string>> GetAllRolesAsync();
        string? GetUserId();
        Task<bool> CreateRoleAsync(string roleName);
    }
}
