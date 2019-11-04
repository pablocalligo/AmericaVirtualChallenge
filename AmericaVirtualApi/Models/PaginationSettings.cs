using AmericaVirtualApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Models
{
    public class PaginationSettings : IPaginationSettings
    {
        public int ItemsPerPage { get; set; }
    }
}
