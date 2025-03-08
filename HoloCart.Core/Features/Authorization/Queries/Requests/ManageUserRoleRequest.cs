using HoloCart.Core.Bases;
using HoloCart.Data.Responses;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Queries.Requests
{

    public class ManageUserRoleRequest : IRequest<Response<ManageUserRoleResponse>>
    {
        public int Id { set; get; }
        public ManageUserRoleRequest(int id)
        {
            Id = id;
        }

    }
}
