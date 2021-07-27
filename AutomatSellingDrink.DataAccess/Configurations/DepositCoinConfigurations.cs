using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatSellingDrink.DataAccess.Configurations
{
    public class DepositCoinConfigurations: IEntityTypeConfiguration<Entities.DepositCoin>
    {
        public void Configure(EntityTypeBuilder<Entities.DepositCoin> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}