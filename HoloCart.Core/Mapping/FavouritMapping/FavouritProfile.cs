using AutoMapper;

namespace HoloCart.Core.Mapping.FavouritMapping
{
    public partial class FavouritProfile : Profile
    {
        public FavouritProfile()
        {
            AddToFavouritMapping();
            GetAllFavouritsMapping();
        }
    }
}
