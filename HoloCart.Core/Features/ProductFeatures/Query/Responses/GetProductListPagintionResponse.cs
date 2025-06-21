namespace HoloCart.Core.Features.ProductFeatures.Query.Responses
{
    public class GetProductListPagintionResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public string MainImageUrl { get; set; }
        public string? ModelUrl { get; set; } // Optional 3D model file
        public bool IsModel3D { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsFavorite { get; set; }


        // Discount Info
        public int? DiscountId { get; set; }
        public string DiscountCode { get; set; }
        public decimal? DiscountPercentage { get; set; }

        public List<ReviewDto> Reviews { get; set; }

        // Computed FinalPrice (AutoMapper will calculate this dynamically)
        public decimal FinalPrice { get; set; }
    }
}


