using Saggezza_SuplierDeliveryService.Domain.Entities;

namespace Saggezza_SuplierDeliveryService.Domain.Interfaces
{
    public interface IDeliveryRepository
    {
        public  Task<Delivery> Add(Delivery delivery);
        public  Task<List<Delivery>> GetAll();
    }
}
