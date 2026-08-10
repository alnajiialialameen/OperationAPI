using System.ComponentModel.DataAnnotations;

namespace OperationAPI.Application.Models.IdentityModel
{
    public class RegisterationRequest
    {
        public string? FullName { get; set; }
        //public string? FirstName { get; set; }

        //public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(8)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(8)]
        public string? Password { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public List<string>? UserRoles { get; set; }
    }
}
