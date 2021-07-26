using Microsoft.EntityFrameworkCore;

namespace AutomatSellingDrink.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
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
    }
}