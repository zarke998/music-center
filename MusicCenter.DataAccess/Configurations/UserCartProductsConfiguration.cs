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
    public class UserCartProductsConfiguration : IEntityTypeConfiguration<UserCartProduct>
    {
        public void Configure(EntityTypeBuilder<UserCartProduct> builder)
        {
            builder.HasOne(x => x.Product).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithMany(u => u.CartProducts).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
