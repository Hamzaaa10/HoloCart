using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Command.Requests
{
    public class DeleteDiscountCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteDiscountCommand(int id)
        {
            this.id = id;
        }
    }
}
