using ECommerceTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Domain.Interfaces
{
    public interface IAuthService
    {
        void CreateHashPassword(string password, out byte[] passwordhash, out byte[] passwordsalt);
        bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt);
        string CreateToken(User user);
        RefreshToken CreateRefreshToken();

    }
}
