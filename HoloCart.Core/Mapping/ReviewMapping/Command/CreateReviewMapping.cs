using HoloCart.Core.Features.ReviewFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile
    {
        public void CreateReviewMapping()
        {
            CreateMap<CreateReviewCommnd, Review>().ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => DateTime.UtcNow));


        }
    }
}
