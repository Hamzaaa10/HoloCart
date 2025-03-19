using HoloCart.Core.Features.ReviewFeatures.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile
    {
        public void GetAllReviewsWithProductMapping()
        {
            CreateMap<Review, GetReviewsByProductResponse>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                                                   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUserId))
                                                   .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.ReviewDate));
            ;


        }
    }
}
