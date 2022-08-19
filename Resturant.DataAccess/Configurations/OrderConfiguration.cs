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
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class OrderItemConfiguration : EntityConfiguration<OrderItem>
    {
        protected override void ConfigureRules(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Quantity).HasMaxLength(20).IsRequired();
        }
    }
}
