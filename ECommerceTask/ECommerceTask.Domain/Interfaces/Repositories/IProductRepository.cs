using ECommerceTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTask.Domain.Entities;

namespace ECommerceTask.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetById(string id);
        void Update(Product product);
        void Delete(Product product);
        Task<IEnumerable<Product>> GetProducts(int PageIndex, int PageSize);
    }
}
