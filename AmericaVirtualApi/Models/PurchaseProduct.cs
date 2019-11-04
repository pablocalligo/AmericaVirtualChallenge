using AmericaVirtualApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Models
{
    public class PurchaseProduct
    {
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
