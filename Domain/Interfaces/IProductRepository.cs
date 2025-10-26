using Saggezza_SuplierDeliveryService.Domain.Entities;

namespace Saggezza_SuplierDeliveryService.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> Add(Product product);
        public Task<Product> GetById(int id);
    }
}
