using System.ComponentModel.DataAnnotations;

namespace RewardApp.Api.Models
{
    public class Member
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string MobileNumber { get; set; } = string.Empty;

        public string? Otp { get; set; }

        public DateTime? OtpExpiryTime { get; set; }

        public int Points { get; set; }

        [Required]
        [StringLength(10)]
        public string Role { get; set; } = "User";
    }
}