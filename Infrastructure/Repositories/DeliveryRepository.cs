using Microsoft.EntityFrameworkCore;
using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;
using Saggezza_SuplierDeliveryService.Infrastructure.Data;

namespace Saggezza_SuplierDeliveryService.Infrastructure.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery> Add(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }

        public async Task<List<Delivery>> GetAll()
        {
            return await _context.Deliveries
                .Include(d => d.SupplierId)
                .Include(d => d.ProductId)
                .ToListAsync();
        }
    }
}
