using ECommerceTask.Domain.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.DTOs
{
    public class AuthModel
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public UserType UserType { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
