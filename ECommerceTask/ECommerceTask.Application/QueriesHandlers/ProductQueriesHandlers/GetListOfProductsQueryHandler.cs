using ECommerceTask.Application.Queries.ProductQueries;
using ECommerceTask.Domain.Entities;
using ECommerceTask.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.QueriesHandlers.ProductQueriesHandlers
{
    internal class GetListOfProductsQueryHandler : IRequestHandler<GetListOfProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;

        public GetListOfProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetListOfProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProducts(request.PageIndex, request.PageSize);
        }
    }
}
