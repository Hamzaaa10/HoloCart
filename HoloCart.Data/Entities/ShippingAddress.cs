using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities
{
    public class ShippingAddress
    {
        public int Id { get; set; }

        // Each shipping address is linked to a user.
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        [Required, MaxLength(255)]
        public string AddressLine1 { get; set; }

        [MaxLength(255)]
        public string? AddressLine2 { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [Required, MaxLength(20)]
        public string PostalCode { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Order> Orders { get; set; }
    }

}