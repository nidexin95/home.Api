using home.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace home.Api.Servcie
{
    public interface IUserService
    {
        void AddUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid userId);
        Task SaveAsync(); 
    }
}
