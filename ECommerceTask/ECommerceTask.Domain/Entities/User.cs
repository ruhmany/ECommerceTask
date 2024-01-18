using ECommerceTask.Domain.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserType UserType { get; set; }
        public DateTime LastLoginTime { get; set; }

        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}
