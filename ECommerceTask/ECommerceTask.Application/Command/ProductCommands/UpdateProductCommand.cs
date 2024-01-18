using ECommerceTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Command.ProductCommands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
