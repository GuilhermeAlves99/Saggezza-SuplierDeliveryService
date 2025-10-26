namespace Saggezza_SuplierDeliveryService.Domain.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
