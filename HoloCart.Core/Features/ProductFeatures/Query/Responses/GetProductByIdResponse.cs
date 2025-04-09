namespace HoloCart.Core.Features.ProductFeatures.Query.Responses
{
    public class GetProductByIdResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public string MainImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsFavorite { get; set; }

        public int? DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public List<ProductColorDto> Colors { get; set; }

        public List<ReviewDto> Reviews { get; set; }

        // Computed FinalPrice (AutoMapper will calculate this dynamically)
        public decimal FinalPrice { get; set; }
    }
    public class ProductColorDto
    {
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public string ImageUrl { get; set; }
    }
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
    }
}
