using HoloCart.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace HoloCart.Data.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        // NEW: Stripe Payment Intent ID
        [MaxLength(100)]
        public string? PaymentIntentId { get; set; }


        // A cart contains many items.
        public virtual ICollection<CartItem> CartItems { get; set; }
        public string? DiscountCode { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}

