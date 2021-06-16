using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.DTO
{
    public class CreateOrderDto
    {
        public string ShippingAdress { get; set; }
        public int UserId { get; set; }
    }
}
