using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.FavouriteFeatures.Command.Requests
{
    public class AddToFavouritesCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
