using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Responses;
using HoloCart.Core.Wrappers;
using MediatR;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Queries.Requests
{
    public class GetApplicationUsersPaginatedRequest : IRequest<PaginatedResult<GetApplicationUserPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
