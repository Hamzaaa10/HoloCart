namespace HoloCart.Data.Entities
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }

        // Optional reverse navigation
        public virtual ProductColor ProductColor { get; set; }
    }
}