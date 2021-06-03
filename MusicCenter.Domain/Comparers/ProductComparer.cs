using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Comparers
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (x == null || y == null)
                return false;

            return x.Id == y.Id || x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Id;
        }
    }
}
