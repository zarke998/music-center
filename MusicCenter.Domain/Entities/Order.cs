using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{
    public class Order : Entity
    {
        public string ShippingAdress { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
