using System.ComponentModel.DataAnnotations;

namespace RewardApp.Api.Dtos
{
    public class RedeemPointsDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Points to redeem must be greater than 0.")]
        public int Points { get; set; }
    }
}
