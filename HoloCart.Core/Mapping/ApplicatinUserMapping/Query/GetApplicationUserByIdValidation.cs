using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Responses;
using HoloCart.Data.Entities.Identity;

namespace HoloCart.Core.Mapping.ApplicatinUserMapping
{
    public partial class ApplicationAuthorizationProfile
    {
        public void GetApplicationUserByIdValidation()
        {
            CreateMap<ApplicationUser, GetApplicationUserByIdResponse>();

        }

    }
}
