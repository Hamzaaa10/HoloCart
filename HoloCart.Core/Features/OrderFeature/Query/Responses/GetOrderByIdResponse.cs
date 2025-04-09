namespace HoloCart.Core.Features.OrderFeature.Query.Responses
{
    public class GetOrderByIdResponse
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal DiscountPercntage { get; set; }
        public string DiscountCode { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ProductDiscount { get; set; }
    }
}


