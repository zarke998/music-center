﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((double)TotalCount / ItemsPerPage);

        public IEnumerable<T> Items { get; set; }
    }
}
