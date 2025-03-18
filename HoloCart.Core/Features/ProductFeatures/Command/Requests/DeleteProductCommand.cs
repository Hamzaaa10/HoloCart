using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Command.Requests
{
    public class DeleteProductCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteProductCommand(int id)
        {
            this.id = id;
        }
    }
}
