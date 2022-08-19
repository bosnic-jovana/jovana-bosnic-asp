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
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(x => x.UserUseCases).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
