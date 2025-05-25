using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ProductColorFeature.Command.Requests
{
    public class UpdateProductColorCommand : IRequest<Response<string>>
    {
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }

        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public int Stock { get; set; }

        public int? ProductImageId { get; set; }
    }
}
