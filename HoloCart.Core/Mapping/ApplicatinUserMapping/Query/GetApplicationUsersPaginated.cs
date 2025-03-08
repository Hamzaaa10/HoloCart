using AutoMapper;
using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Responses;
using HoloCart.Data.Entities.Identity;

namespace HoloCart.Core.Mapping.ApplicatinUserMapping
{
    public partial class ApplicationAuthorizationProfile : Profile
    {
        public void GetApplicationUsersPaginated()
        {
            CreateMap<ApplicationUser, GetApplicationUserPaginatedResponse>();

        }
    }
}
