using System.Net.Mime;
using AutomatSellingDrink.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatSellingDrink.DataAccess.Configurations
{
    public class DrinkConfiguration: IEntityTypeConfiguration<Entities.Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.OwnsOne(x => x.Image).HasOne<Entities.File>();
            builder.HasOne(x => x.Image).WithOne();
        }
    }
}