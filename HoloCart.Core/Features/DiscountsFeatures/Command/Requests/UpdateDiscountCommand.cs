using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Command.Requests
{
    public class UpdateDiscountCommand : CreateDiscountCommand, IRequest<Response<string>>
    {
        public int id { get; set; }
    }
}
