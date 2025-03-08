using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Requests
{
    public class DeleteRoleRequest : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteRoleRequest(int id)
        {
            Id = id;
        }
    }
}
