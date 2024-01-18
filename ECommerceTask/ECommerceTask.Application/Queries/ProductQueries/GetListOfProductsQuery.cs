using ECommerceTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Queries.ProductQueries
{
    public class GetListOfProductsQuery : IRequest<IEnumerable<Product>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
