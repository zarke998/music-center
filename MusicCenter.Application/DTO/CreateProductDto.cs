using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.DTO
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public string ImageUrl { get; set; }

        public int BrandId { get; set; }
        public ICollection<int> Categories { get; set; }
    }
}
