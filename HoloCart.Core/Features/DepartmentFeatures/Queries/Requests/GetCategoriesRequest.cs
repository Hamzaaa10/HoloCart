using HoloCart.Core.Bases;
using HoloCart.Core.Features.DepartmentFeatures.Queries.Responses;
using MediatR;

namespace HoloCart.Core.Features.DepartmentFeatures.Queries.Requests
{
    public class GetCategoriesRequest : IRequest<Response<List<GetAllCategoriesResponse>>>
    {
    }
}
