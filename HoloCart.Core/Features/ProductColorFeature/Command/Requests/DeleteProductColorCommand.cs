using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ProductColorFeature.Command.Requests
{
    public class DeleteProductColorCommand : IRequest<Response<string>>
    {
        public int ProductColorId { get; set; }
        public DeleteProductColorCommand(int id)
        {
            ProductColorId = id;
        }

    }
}
