using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;

namespace Saggezza_SuplierDeliveryService.Application.UseCases
{
    public class CreateSupplier
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplier(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository ?? throw new ArgumentNullException(nameof(supplierRepository));
        }

        public async Task<Supplier> Execute(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Precisa de um nome válido.");

            var supplier = new Supplier { Name = name };
            return await _supplierRepository.Add(supplier);
        }
    }
}
