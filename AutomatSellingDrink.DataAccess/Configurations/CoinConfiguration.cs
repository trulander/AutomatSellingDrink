using AutomatSellingDrink.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatSellingDrink.DataAccess.Configurations
{
    public class CoinConfiguration: IEntityTypeConfiguration<Entities.Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Coins)
                .HasForeignKey(x=>x.UserId)
                .HasPrincipalKey(x=>x.Id);
        }
    }
}