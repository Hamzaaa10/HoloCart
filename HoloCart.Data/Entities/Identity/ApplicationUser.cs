using Microsoft.AspNetCore.Identity;

namespace HoloCart.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Code { get; set; }
        public byte[]? ProfileImage { get; set; }
        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

        //tracks the products this user has favorited
        public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
        public virtual Cart Cart { get; set; }
    }
}
