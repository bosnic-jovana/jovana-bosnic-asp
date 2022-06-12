using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resturant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataAccess.Configurations
{
    public class PricelistConfiguration : EntityConfiguration<Pricelist>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Pricelist> builder)
        {
            builder.Property(x => x.Price).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Pricelist)
                   .HasForeignKey(x => x.PricelistId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
