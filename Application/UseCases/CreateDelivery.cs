using Saggezza_SuplierDeliveryService.Domain.Entities;
using Saggezza_SuplierDeliveryService.Domain.Interfaces;

namespace Saggezza_SuplierDeliveryService.Application.UseCases
{
    public class CreateDelivery
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public CreateDelivery(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }
        public async Task<Delivery> Execute(Delivery delivery)
        {
            if (delivery.Quantity <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
            return await _deliveryRepository.Add(delivery);
        }
    }
}
