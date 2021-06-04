using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Searches
{
    public class ProductSearch : PagedSearch
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
