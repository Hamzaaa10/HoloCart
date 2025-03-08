using AutoMapper;

namespace HoloCart.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetAllRolesMapping();
            GetRoleByIdMapping();
        }
    }
}
