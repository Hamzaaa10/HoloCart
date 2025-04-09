using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.OrderFeature.Command.Requests
{
    public class DeleteOrderCommand : IRequest<Response<string>>
    {
        public int OrderId { get; set; }

        public DeleteOrderCommand(int id)
        {
            OrderId = id;
        }
    }
}
