using HoloCart.Core.Features.ProductFeatures.Query.Responses;
using HoloCart.Core.Wrappers;
using HoloCart.Data.Enums.Product;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Query.Requests
{
    public class GetProductListPagintionQuery : IRequest<PaginatedResult<GetProductListPagintionResponse>>
    {
        public int ApplicationUserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchBy { get; set; }
        public ProductOrderingEnum OrderBy { get; set; }


    }
}
