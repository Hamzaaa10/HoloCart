namespace HoloCart.Core.Features.ReviewFeatures.Query.Responses
{
    public class GetReviewsByProductResponse
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
