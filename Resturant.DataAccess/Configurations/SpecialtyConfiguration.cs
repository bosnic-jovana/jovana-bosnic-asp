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
    public class SpecialtyConfiguration : EntityConfiguration<Specialty>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Specialty> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Weight).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.SpecialtyIngredients)
                   .WithOne(x => x.Specialty)
                   .HasForeignKey(x => x.SpecialtyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Pricelists)
                  .WithOne(x => x.Specialty)
                  .HasForeignKey(x => x.SpecialtyId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class IngredientConfiguration : EntityConfiguration<Ingredient>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.SpecialtyIngredients)
                   .WithOne(x => x.Ingredient)
                   .HasForeignKey(x => x.IngredientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
