using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities
{

    public class ProductDiscount
    {
        // Composite key: ProductId + DiscountId 
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int DiscountId { get; set; }

        // Navigation properties
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }
    }


}