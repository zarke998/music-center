using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Comparers
{
    public class UserCartProductComparer : IEqualityComparer<UserCartProduct>
    {
        public bool Equals(UserCartProduct x, UserCartProduct y)
        {
            if (x == null || y == null)
                return false;

            return (x.ProductId == y.ProductId && x.UserId == y.UserId);
        }

        public int GetHashCode([DisallowNull] UserCartProduct obj)
        {
            return obj.Id;
        }
    }
}
