using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Searches
{
    public class OrderSearch : PagedSearch
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public string ShippingAdress { get; set; }
        public int? UserId { get; set; }
    }
}
