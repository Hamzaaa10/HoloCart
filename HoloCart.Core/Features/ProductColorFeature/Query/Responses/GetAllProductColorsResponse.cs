namespace HoloCart.Core.Features.ProductColorFeature.Query.Responses
{
    public class GetAllProductColorsResponse
    {
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public int Stock { get; set; }


        // Instead of just ProductImageId, include full image details
        public ProductImageResponseDto Image { get; set; }
    }
    public class ProductImageResponseDto
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
    }
}
