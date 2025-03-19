using AutoMapper;

namespace HoloCart.Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateReviewMapping();
            UpdateReviewMapping();
            GetAllReviewsWithProductMapping();

        }
    }
}
