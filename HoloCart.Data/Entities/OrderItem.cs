namespace HoloCart.Data.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        // FK to Order
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        // FK to Product
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}