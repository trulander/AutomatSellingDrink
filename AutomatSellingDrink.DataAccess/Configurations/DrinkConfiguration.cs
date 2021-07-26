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

            //builder.ToTable("Images");

            builder.HasOne(x => x.Image)
                .WithOne(x => x.Drink)
                .HasForeignKey<Drink>(x => x.FileId)
                .HasPrincipalKey<File>(x => x.Id);
        }
    }
}