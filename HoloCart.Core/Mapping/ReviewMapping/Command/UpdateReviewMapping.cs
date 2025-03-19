using HoloCart.Core.Features.ReviewFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile
    {
        public void UpdateReviewMapping()
        {
            CreateMap<UpdateReviewCommnd, Review>().ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.updateDto.Rating))
                                                   .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.updateDto.Comment));


        }
    }
}
