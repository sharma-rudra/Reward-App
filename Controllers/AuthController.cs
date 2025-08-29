using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardApp.Api.Data;
using RewardApp.Api.Dtos;
using RewardApp.Api.Models;
using RewardApp.Api.Services;

namespace RewardApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(ApplicationDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var memberExists = await _context.Members.AnyAsync(m => m.MobileNumber == registerDto.MobileNumber);
            if (memberExists)
            {
                return BadRequest("A member with this mobile number already exists.");
            }

            var member = new Member
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                MobileNumber = registerDto.MobileNumber,
                Otp = "123456", // Dummy OTP for all users
                OtpExpiryTime = DateTime.UtcNow.AddMinutes(10),
                Points = 0,
                Role = "User"
            };

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful. Please verify OTP." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.MobileNumber == loginDto.MobileNumber);

            if (member == null || member.Otp != loginDto.Otp)
            {
                return Unauthorized("Invalid mobile number or OTP.");
            }

            // The following lines are commented out to allow repeated logins with the same OTP.
            // member.Otp = null;
            // member.OtpExpiryTime = null;
            // await _context.SaveChangesAsync();

            // Create the JWT token
            var token = _tokenService.CreateToken(member);

            return Ok(new
            {
                Message = "Login successful.",
                Role = member.Role,
                Token = token
            });
        }
    }
}
