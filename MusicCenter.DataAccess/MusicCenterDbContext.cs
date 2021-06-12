using Microsoft.EntityFrameworkCore;
using MusicCenter.Domain.Entities;
using MusicCenter.EfDataAccess.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.EfDataAccess
{
    public class MusicCenterDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=MusicCenter;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserCartProductsConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserUseCaseConfiguration());

            modelBuilder.ApplyGlobalFilter<Entity>(e => e.IsDeleted == false);
        }

        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries();

            foreach(var entry in entries)
            {
                var entity = entry.Entity as Entity;
                if (entity == null)
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.IsDeleted = false;
                        entity.IsActive = true;
                        entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entity.ModifiedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entity.IsDeleted = true;
                        entity.DeletedAt = DateTime.UtcNow;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<UserCartProduct> UserCartProducts { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
