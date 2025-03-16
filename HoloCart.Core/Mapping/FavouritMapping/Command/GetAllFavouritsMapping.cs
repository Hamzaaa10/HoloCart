using HoloCart.Core.Features.FavouriteFeatures.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.FavouritMapping
{
    public partial class FavouritProfile
    {
        public void GetAllFavouritsMapping()
        {
            CreateMap<Favourite, GetAllFavouritsResponse>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId))
            .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.Product.MainImageUrl))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.Product.BasePrice))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description));

        }
    }
}
