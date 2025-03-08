using HoloCart.Data.Entities.Identity;

namespace HoloCart.Data.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        // A cart contains many items.
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}

