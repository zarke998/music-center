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
    public class UseCaseLogConfiguration: IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.Property(x => x.UseCaseName).IsRequired();
            builder.HasOne(x => x.User).WithMany(u => u.UseCaseLogs).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
