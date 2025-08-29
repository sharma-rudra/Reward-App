using Microsoft.EntityFrameworkCore;
using RewardApp.Api.Models;

namespace RewardApp.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}