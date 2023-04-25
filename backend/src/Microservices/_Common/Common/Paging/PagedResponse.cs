﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Paging
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
