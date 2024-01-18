using ECommerceTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public string Id { get; set; }
    }
}
