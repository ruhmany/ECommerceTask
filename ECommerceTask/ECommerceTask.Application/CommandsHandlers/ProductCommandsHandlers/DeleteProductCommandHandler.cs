using ECommerceTask.Application.Command.ProductCommands;
using ECommerceTask.Domain.Interfaces.Repositories;
using ECommerceTask.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTask.Domain.Entities;

namespace ECommerceTask.Application.CommandsHandlers.ProductCommandsHandlers
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitodwork;

        public DeleteProductCommandHandler(IUnitOfWork unitodwork, IProductRepository productRepository)
        {
            _unitodwork = unitodwork;
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetById(request.ID);
            if(result != null) 
            {
                _productRepository.Delete(result);
                await _unitodwork.CommitChangesAsync();
            }
            return result;
        }
    }
}
