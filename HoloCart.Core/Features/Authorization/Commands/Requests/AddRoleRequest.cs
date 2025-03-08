using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Requests
{
    public class AddRoleRequest : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
