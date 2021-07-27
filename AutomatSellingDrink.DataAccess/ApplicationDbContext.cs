using AutomatSellingDrink.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomatSellingDrink.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.CoinConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.DrinkConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FileConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Entities.Coin> Coins { get; set; }
        public DbSet<Entities.Drink> Drinks { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.File> Files { get; set; }
    }
}