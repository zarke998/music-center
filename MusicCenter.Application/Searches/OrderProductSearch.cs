using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Searches
{
    public class OrderProductSearch : PagedSearch
    {
        public string Name { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
    }
}
