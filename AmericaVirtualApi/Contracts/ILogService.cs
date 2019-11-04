using AmericaVirtualApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Contracts
{
    public interface ILogService
    {
        List<Log> GetAll();
        List<Log> GetByUserId(string userId);
        Log Create(Log log);
    }
}
