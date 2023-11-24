using HomeMgmtAPI.DataLayer.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace HomeMgmtAPI.DataLayer
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>()
                        .HasOne(h => h.Address)
                        .WithOne(a => a.Home);

            modelBuilder.Entity<Home>()
                        .HasMany(h => h.Rooms)
                        .WithOne(r => r.Home)
                        .HasForeignKey(r => r.HomeId);

        }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
