using AutoMapper;
using ECommerceTask.Application.Command.ProductCommands;
using ECommerceTask.Domain.Entities;
using ECommerceTask.Domain.Interfaces.Repositories;
using ECommerceTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.CommandsHandlers.ProductCommandsHandlers
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitodwork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitodwork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitodwork = unitodwork;
            _mapper = mapper;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if(product != null)
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.ImagePath = request.ImagePath;
                product.MinQuantity = request.MinQuantity;
                product.Category = request.Category;
                product.DiscountRate = request.DiscountRate;

                _productRepository.Update(product);
                await _unitodwork.CommitChangesAsync();
            }
            return product;
        }
    }
}
