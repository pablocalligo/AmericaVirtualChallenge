using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Contracts
{
    public interface IPaginationSettings
    {
        int ItemsPerPage { get; set; }

    }
}
