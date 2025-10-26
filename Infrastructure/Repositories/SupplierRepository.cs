using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;
using Saggezza_SuplierDeliveryService.Infrastructure.Data;

namespace Saggezza_SuplierDeliveryService.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar: {ex.Message}");
                throw;
            }
            return supplier;
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }
    }
}
