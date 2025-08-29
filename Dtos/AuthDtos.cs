using System.ComponentModel.DataAnnotations;

namespace RewardApp.Api.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string MobileNumber { get; set; } = string.Empty;
    }

    public class LoginDto
    {
        [Required]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        public string Otp { get; set; } = string.Empty;
    }
}