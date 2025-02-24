using System.ComponentModel.DataAnnotations;

namespace HoloCart.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }

}