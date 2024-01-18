using ECommerceTask.Domain.Entities;
using ECommerceTask.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTask.Infrastructre.Presistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> GetById(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Code.ToString() == id);
        }

        public async Task<IEnumerable<Product>> GetProducts(int PageIndex, int PageSize)
        {
            return await _context.Products.Skip(PageIndex*PageSize).Take(PageSize).ToListAsync();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
