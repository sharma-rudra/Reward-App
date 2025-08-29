using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardApp.Api.Data;
using RewardApp.Api.Dtos;

namespace RewardApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("points")]
        public async Task<IActionResult> GetMemberPoints()
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (memberId == null)
            {
                return Unauthorized();
            }

            var member = await _context.Members.FindAsync(Guid.Parse(memberId));
            if (member == null)
            {
                return NotFound("Member not found.");
            }

            return Ok(new { Points = member.Points });
        }

        [HttpPost("redeem")]
        public async Task<IActionResult> RedeemPoints([FromBody] RedeemPointsDto redeemDto)
        {
            var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (memberId == null)
            {
                return Unauthorized();
            }

            var member = await _context.Members.FindAsync(Guid.Parse(memberId));
            if (member == null)
            {
                return NotFound("Member not found.");
            }

            if (member.Points < redeemDto.Points)
            {
                return BadRequest("Insufficient points.");
            }

            member.Points -= redeemDto.Points;
            await _context.SaveChangesAsync();

            decimal redeemedValue = (decimal)redeemDto.Points / 10;

            return Ok(new
            {
                Message = $"Successfully redeemed {redeemDto.Points} points. An amount of ₹{redeemedValue:F2} has been credited.",
                NewPoints = member.Points
            });
        }
    }
}
