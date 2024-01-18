using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Domain.Entities
{
    
    public class RefreshToken
    {
        public int ID { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredOn { get; set; }
        public bool IsValid => DateTime.Now >= ExpiredOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokeOn { get; set; }
        public bool IsActive => RevokeOn == null && !IsValid;
    }
}
