using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;
using Saggezza_SuplierDeliveryService.Infrastructure.Data;

namespace Saggezza_SuplierDeliveryService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
