using GyakTura.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GyakTura.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Tour> Tours { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}