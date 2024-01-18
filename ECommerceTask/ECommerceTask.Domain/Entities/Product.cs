using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Domain.Entities
{
    public class Product
    {
        public Guid Code { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
