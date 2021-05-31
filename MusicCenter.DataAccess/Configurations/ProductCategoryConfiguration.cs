using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.EfDataAccess.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasOne(x => x.Product).WithMany(p => p.ProductCategories).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Category).WithMany(c => c.CategoryProducts).OnDelete(DeleteBehavior.Cascade);
        }
    }
}