using Microsoft.EntityFrameworkCore;

namespace AutomatSellingDrink.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new entity());

            base.OnModelCreating(modelBuilder);
        }
    }
}