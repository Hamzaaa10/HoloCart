using HoloCart.Data.Entities.Identity;

namespace HoloCart.Data.Entities
{
    public class Favourite
    {
        public int FavouriteId { get; set; }

        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}