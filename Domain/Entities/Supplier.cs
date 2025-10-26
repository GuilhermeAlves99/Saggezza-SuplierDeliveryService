using Saggezza_SuplierDeliveryService.Controllers;

namespace Saggezza_SuplierDeliveryService.Domain.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
