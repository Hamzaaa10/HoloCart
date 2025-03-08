using HoloCart.Core.Bases;
using HoloCart.Data.Requests;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Requests
{
    public class UpdateUserRoleRequest : EditUserRolesRequest, IRequest<Response<string>>
    {
    }
}
