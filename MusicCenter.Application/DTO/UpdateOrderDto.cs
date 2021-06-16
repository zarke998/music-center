using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.DTO
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public string ShippingAdress { get; set; }
        public int? UserId { get; set; }
    }
}
