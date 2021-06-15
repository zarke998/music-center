using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public string UseCaseName { get; set; }
        public int? UseCaseId { get; set; }

        public int? UserId { get; set; }
    }
}
