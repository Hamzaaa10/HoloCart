using HoloCart.Core.Bases;
using HoloCart.Data.Responses;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Queries.Requests
{
    public class ManageUserClaimsRequest : IRequest<Response<ManageUserClaimsResponse>>
    {
        public int Id { get; set; }
        public ManageUserClaimsRequest(int id)
        {
            Id = id;
        }
    }
}
