using Microsoft.AspNetCore.Identity;

namespace OperationAPI.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool RequiresPasswordChange { get; set; } = true;
    }
}

