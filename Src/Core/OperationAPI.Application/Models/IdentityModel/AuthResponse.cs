using OperationAPI.Domain;

namespace OperationAPI.Application.Models.IdentityModel
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public int Id { get; set; } = 0;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public AirLineAgentDomain? AirlineAgent { get; set; }
    }
}
