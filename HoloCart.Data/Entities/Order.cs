using HoloCart.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace HoloCart.Data.Entities
{

    public class Order
    {
        public int OrderId { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // NEW: Stripe Payment Intent ID
        [MaxLength(100)]
        public string? PaymentIntentId { get; set; }


        // FK to ShippingAddress
        public int ShippingAddressId { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }

        // Optional discount applied to the order
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Payment Payment { get; set; }
    }


}