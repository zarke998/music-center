using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Comparers
{
    public class ProductCategoryComparer : IEqualityComparer<ProductCategory>
    {
        public bool Equals(ProductCategory x, ProductCategory y)
        {
            if (x == null || y == null)
                return false;

            return (x.ProductId == y.ProductId && x.CategoryId == y.CategoryId);
        }

        public int GetHashCode([DisallowNull] ProductCategory obj)
        {
            return obj.Id;
        }
    }
}
