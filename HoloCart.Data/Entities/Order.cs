using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }

        // Each order belongs to a user.
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        // The shipping address used for this order (optional).
        public int? ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual ShippingAddress ShippingAddress { get; set; }

        public OrderStatus Status { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navigation properties
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Payment Payment { get; set; }
    }


}