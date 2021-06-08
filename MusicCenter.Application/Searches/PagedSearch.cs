using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Searches
{
    public abstract class PagedSearch
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 8;
    }
}
