using System.ComponentModel.DataAnnotations;

namespace HoloCart.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } // URL for category image
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property: One Category can have many Products.
        public virtual ICollection<Product> Products { get; set; }
    }
}
