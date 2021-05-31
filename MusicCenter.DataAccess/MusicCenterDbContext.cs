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

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
