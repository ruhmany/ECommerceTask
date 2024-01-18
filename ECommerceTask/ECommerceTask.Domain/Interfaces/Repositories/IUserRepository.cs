using ECommerceTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        void Update(User user);
        void Delete(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetUserByUsername(string username);
    }
}
