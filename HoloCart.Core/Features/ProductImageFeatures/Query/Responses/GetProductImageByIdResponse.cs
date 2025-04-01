namespace HoloCart.Core.Features.ProductImageFeatures.Query.Responses
{
    public class GetProductImageByIdResponse
    {
        public int ProductImageId { get; set; }
        public int ProductColorId { get; set; }
        public string ImageUrl { get; set; }
    }
}
