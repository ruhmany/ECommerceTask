using ECommerceTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Command.ProductCommands
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public string ID { get; set; }
    }
}
