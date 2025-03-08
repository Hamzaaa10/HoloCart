using HoloCart.Data.Entities.Identity;

namespace HoloCart.Data.Entities
{


    public class Review
    {
        public int ReviewId { get; set; }

        // FK to Product
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        // FK to ApplicationUser
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int Rating { get; set; }          // e.g., 1-5 stars
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }

}
