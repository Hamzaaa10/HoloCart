using AutoMapper;
using HoloCart.Core.Features.Authorization.Queries.Responses;
using HoloCart.Data.Entities.Identity;

namespace HoloCart.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile : Profile
    {

        public void GetRoleByIdMapping()
        {
            CreateMap<ApplicationRole, GetRoleByIdResponse>();

        }
    }
}
