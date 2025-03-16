using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.FavouriteFeatures.Command.Requests
{
    public class RemoveFavouriteCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
