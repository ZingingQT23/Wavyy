using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wavyy.Models;
using Wavyy.Models.Games;

namespace Wavyy.Data
{
    public class WavyyDbContext : IdentityDbContext<ApplicationUser>
    {
        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserCollectionGame> UserCollectionGames { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformGame> PlatformGames { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherGame> PublisherGames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<DeveloperGame> DeveloperGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreGame> GenreGames { get; set; }

        public DbSet<GameImage> GameImages { get; set; }


        public WavyyDbContext(DbContextOptions<WavyyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}
