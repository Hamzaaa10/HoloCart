using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities
{
    public class ProductVariant
    {
        public int Id { get; set; }

        // Each variant belongs to one product.
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required, MaxLength(100)]
        public string VariantName { get; set; }

        [Required, MaxLength(50)]
        public string SKU { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AdditionalPrice { get; set; }

        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

}