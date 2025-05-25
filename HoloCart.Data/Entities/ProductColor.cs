namespace HoloCart.Data.Entities
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }

        // FK to Product
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public int Stock { get; set; }

        // One-to-one: Each ProductColor has exactly one associated ProductImage.
        // This FK is stored on the ProductColor.
        public int? ProductImageId { get; set; }
        public virtual ProductImage Image { get; set; }
    }
}