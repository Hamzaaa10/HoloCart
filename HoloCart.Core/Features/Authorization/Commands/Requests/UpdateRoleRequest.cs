using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Requests
{
    public class UpdateRoleRequest : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
