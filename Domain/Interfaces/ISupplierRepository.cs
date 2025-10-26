using Saggezza_SuplierDeliveryService.Domain.Entities;

namespace Saggezza_SuplierDeliveryService.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        public Task<Supplier> Add(Supplier supplier);
        public Task<Supplier> GetById(int id);
    }
}
