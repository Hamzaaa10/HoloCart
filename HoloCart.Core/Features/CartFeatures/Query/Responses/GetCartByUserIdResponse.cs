namespace HoloCart.Core.Features.CartFeatures.Query.Responses
{
    public class GetCartByUserIdResponse
    {

        public int CartId { get; set; }
        public int UserId { get; set; }
        public List<CartItemResponseDto> CartItems { get; set; } = new List<CartItemResponseDto>();
        public decimal CartTotal => CartItems.Sum(item => item.TotalPrice);
        public string? DiscountCode { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal FinalTotal
        {
            get; set;

        }
        public class CartItemResponseDto
        {
            public int CartItemId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal BasePrice { get; set; }
            public decimal DiscountedPrice { get; set; }
            public string MainImageUrl { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => DiscountedPrice * Quantity;
        }
    }
}
