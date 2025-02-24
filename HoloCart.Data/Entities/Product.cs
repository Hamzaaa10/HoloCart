using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; } // URL for product image

        public string Image3DUrl { get; set; } // URL for 3D product image

        [Column(TypeName = "decimal(10,2)")]
        public decimal BasePrice { get; set; }
        //  keep track of the total units sold
        public int TotalSales { get; set; } = 0;
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navigation properties
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
    }

}