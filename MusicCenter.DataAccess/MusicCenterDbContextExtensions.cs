using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.EfDataAccess
{
    public static class MusicCenterDbContextExtensions
    {
        public static bool DatabaseEmpty(this MusicCenterDbContext context)
        {
            bool empty = true;

            if (context.Brands.Any() ||
                context.Categories.Any() ||
                context.Orders.Any() ||
                context.OrderProducts.Any() ||
                context.Products.Any() ||
                context.ProductCategories.Any() ||
                context.UseCaseLogs.Any() ||
                context.Users.Any() ||
                context.UserCartProducts.Any() ||
                context.UserUseCases.Any())
            {
                empty = false;
            }

            return empty;
        }
        public static void ApplyGlobalFilter<TBase>(this ModelBuilder modelBuilder, Expression<Func<TBase, bool>> filter) where TBase : class
        {
            var entities = modelBuilder.Model.GetEntityTypes();

            foreach(var entity in entities)
            {
                var clrType = entity.ClrType;
                if(clrType.IsSubclassOf(typeof(TBase)))
                {
                    var newParam = Expression.Parameter(clrType);
                    var newBody = ReplacingExpressionVisitor.Replace(filter.Parameters.Single(), newParam, filter.Body);
                    modelBuilder.Entity(clrType).HasQueryFilter(Expression.Lambda(newBody, newParam));
                }
            }
        }
    }
}
