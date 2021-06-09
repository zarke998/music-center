using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
