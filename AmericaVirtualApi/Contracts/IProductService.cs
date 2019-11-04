using AmericaVirtualApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Contracts
{
    public interface IProductService
    {
         PaginatedProducts GetPaginated();

         Product Get(string id);

         Product Create(Product product);

         void Update(string id, Product productIn);

         void Remove(string id);
      
    }
}
