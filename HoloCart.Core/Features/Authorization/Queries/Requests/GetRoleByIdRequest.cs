using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Queries.Responses
{
    public class GetRoleByIdRequest : IRequest<Response<GetRoleByIdResponse>>
    {
        public int Id { get; set; }
        public GetRoleByIdRequest(int id)
        {
            Id = id;
        }
    }
}
