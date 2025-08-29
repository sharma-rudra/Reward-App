using System.ComponentModel.DataAnnotations;

namespace RewardApp.Api.Dtos
{
    public class MemberDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int Points { get; set; }
    }

    public class AddPointsDto
    {
        [Required]
        public Guid MemberId { get; set; }

        [Required]
        [Range(100, double.MaxValue)]
        public decimal PurchaseAmount { get; set; }
    }
}