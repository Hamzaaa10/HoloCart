using HoloCart.Core.Features.FavouriteFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.FavouritMapping
{
    public partial class FavouritProfile
    {
        public void AddToFavouritMapping()
        {
            CreateMap<AddToFavouritesCommand, Favourite>().ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.UserId)); ;

        }

    }
}
