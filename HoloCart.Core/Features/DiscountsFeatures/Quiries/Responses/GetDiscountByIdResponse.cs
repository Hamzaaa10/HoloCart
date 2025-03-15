namespace HoloCart.Core.Features.DiscountsFeatures.Quiries.Responses
{
    public class GetDiscountByIdResponse
    {
        public string Code { get; set; }
        public decimal Percentage { get; set; }  // For example, 15 means 15% off.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;

    }
}
