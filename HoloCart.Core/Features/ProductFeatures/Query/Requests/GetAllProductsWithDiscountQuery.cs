using HoloCart.Core.Features.ProductFeatures.Query.Responses;
using HoloCart.Core.Wrappers;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Query.Requests
{
    public class GetAllProductsWithDiscountQuery : IRequest<PaginatedResult<GetAllProductsWithDiscountResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchBy { get; set; }
        public Decimal DiscountPercentage { get; set; }


    }
}
