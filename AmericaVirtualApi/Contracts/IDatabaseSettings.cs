using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Contracts
{
    public interface IDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string LogCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
