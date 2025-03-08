using AutoMapper;

namespace HoloCart.Core.Mapping.ApplicatinUserMapping
{
    public partial class ApplicationAuthorizationProfile : Profile
    {
        public ApplicationAuthorizationProfile()
        {
            AddAplicationUserMapping();
            UpdateAplicationUserMapping();
            GetApplicationUserByIdValidation();
            GetApplicationUsersPaginated();
        }
    }
}
