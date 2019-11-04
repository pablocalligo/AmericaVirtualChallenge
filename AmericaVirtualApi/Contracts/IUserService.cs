using AmericaVirtualApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Contracts
{
    public interface IUserService
    {
        List<User> GetAll();

        User Validate(string username, string password);

        User GetById(string id);

        User Create(User user);

        void Update(string id, User userIn);

        void Remove(string id);

    }
}
