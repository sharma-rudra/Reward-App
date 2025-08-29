using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardApp.Api.Data;
using RewardApp.Api.Dtos;

namespace RewardApp.Api.Controllers
{
    [Authorize(Roles = "Admin")] // This ensures only Admins can access this controller
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("members")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _context.Members
                .Select(m => new MemberDto
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    MobileNumber = m.MobileNumber,
                    Points = m.Points
                })
                .ToListAsync();

            return Ok(members);
        }

        [HttpPost("add-points")]
        public async Task<IActionResult> AddPoints([FromBody] AddPointsDto addPointsDto)
        {
            var member = await _context.Members.FindAsync(addPointsDto.MemberId);

            if (member == null)
            {
                return NotFound("Member not found.");
            }

            int pointsToAdd = (int)(addPointsDto.PurchaseAmount / 100) * 10;
            member.Points += pointsToAdd;

            await _context.SaveChangesAsync();

            return Ok(new { Message = $"{pointsToAdd} points added successfully. New balance is {member.Points}." });
        }
    }
}