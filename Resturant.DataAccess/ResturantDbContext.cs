using Microsoft.EntityFrameworkCore;
using Resturant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataAccess
{
    public class ResturantDbContext : DbContext
    {

        public ResturantDbContext(DbContextOptions options = null) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<SpecialtyIngredient>().HasKey(x => new { x.SpecialtyId, x.IngredientId });
            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.PricelistId, x.OrderId });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        //{
        //    optionsbuilder.UseSqlServer(@"Data Source=DESKTOP-KS3EQ1L\SQLEXPRESS;Initial Catalog=resturantAsp;Integrated Security=True")
        //        .UseLazyLoadingProxies();
        //}

        public IApplicationUser User { get; }
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User?.Identity;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Specialty> Specialities { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<SpecialtyIngredient> SpecialtyIngredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Pricelist> Pricelists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
