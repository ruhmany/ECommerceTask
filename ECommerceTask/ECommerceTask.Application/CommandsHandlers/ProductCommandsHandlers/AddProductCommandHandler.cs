using AutoMapper;
using ECommerceTask.Application.Command.ProductCommands;
using ECommerceTask.Domain.Entities;
using ECommerceTask.Domain.Interfaces;
using ECommerceTask.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.CommandsHandlers.ProductCommandsHandlers
{
    internal class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitodwork;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitodwork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitodwork = unitodwork;
            _mapper = mapper;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddProduct(product);
            await _unitodwork.CommitChangesAsync();
            return product;
        }
    }
}
