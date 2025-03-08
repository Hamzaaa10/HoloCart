using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests
{
    public class DeleteAplicationUserRequest : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteAplicationUserRequest(int id)
        {
            this.id = id;
        }
    }
}
