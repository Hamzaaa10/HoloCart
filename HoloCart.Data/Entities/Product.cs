namespace HoloCart.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        // Main image used on product listing
        public string MainImageUrl { get; set; }

        // FK to Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Optional discount
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        // A product can have many colors (each with its own image)
        public virtual ICollection<ProductColor> Colors { get; set; }
        public virtual ICollection<Favourite> FavouritedBy { get; set; } = new List<Favourite>();

    }


}