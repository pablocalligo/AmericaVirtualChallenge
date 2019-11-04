using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Models
{
    public class PaginatedProducts
    {
        public int TotalPages { get; set; }
        public List<Page> Page { get; set; }
    }

    public class Page
    {
        public int PageNumber { get; set; }
        public List<Product> Products { get; set; }

    }
}
