namespace HoloCart.Data.Entities
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductColorId { get; set; }

        public virtual ProductColor ProductColor { get; set; }
    }
}