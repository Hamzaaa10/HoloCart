using HoloCart.Core.Bases;
using HoloCart.Core.Features.FavouriteFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.FavouriteFeatures.Query.Requests
{
    public class GetAllFavouritsQuery : IRequest<Response<List<GetAllFavouritsResponse>>>
    {
        public int UserId { get; set; }
        public GetAllFavouritsQuery(int UserId)
        {
            this.UserId = UserId;
        }
    }
}
