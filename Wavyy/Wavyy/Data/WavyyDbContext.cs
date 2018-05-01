using Microsoft.EntityFrameworkCore;
using Wavyy.Models;

namespace Wavyy.Data
{
    public class WavyyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WavyyDbContext(DbContextOptions<WavyyDbContext> options)
        : base(options)
        {
        }
    }
}