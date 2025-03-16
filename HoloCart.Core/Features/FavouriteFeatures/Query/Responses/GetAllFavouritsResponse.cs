namespace HoloCart.Core.Features.FavouriteFeatures.Query.Responses
{
    public class GetAllFavouritsResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        // Main image used on product listing
        public string MainImageUrl { get; set; }
    }
}
