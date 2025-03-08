using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authorization.Queries.Responses;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Queries.Requests
{
    public class GetAllRolesRequest : IRequest<Response<List<GetAllRolesResponse>>>
    {
    }
}
