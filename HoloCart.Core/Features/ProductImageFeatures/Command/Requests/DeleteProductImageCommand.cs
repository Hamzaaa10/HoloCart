using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ProductImageFeatures.Command.Requests
{
    public class DeleteProductImageCommand : IRequest<Response<string>>
    {
        public int ProductImageId { get; set; }

        public DeleteProductImageCommand(int id)
        {
            ProductImageId = id;
        }

    }
}
