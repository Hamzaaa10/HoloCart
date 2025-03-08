using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authorization.Queries.Requests;
using HoloCart.Core.Features.Authorization.Queries.Responses;
using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Responses;
using HoloCart.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HoloCart.Core.Features.Authorization.Queries.Handllers
{
    public class AuthorizationQueryHundller : ResponseHandller,
                IRequestHandler<GetAllRolesRequest, Response<List<GetAllRolesResponse>>>,
                IRequestHandler<GetRoleByIdRequest, Response<GetRoleByIdResponse>>,
                IRequestHandler<ManageUserRoleRequest, Response<ManageUserRoleResponse>>,
                IRequestHandler<ManageUserClaimsRequest, Response<ManageUserClaimsResponse>>

    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthorizationQueryHundller(IAuthorizationService authorizationService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<List<GetAllRolesResponse>>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            var Roles = await _authorizationService.GetAllRolesAsync();
            var MappedRules = _mapper.Map<List<GetAllRolesResponse>>(Roles);
            return Success(MappedRules);
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleByIdAsync(request.Id);
            if (role == null) return BadRequest<GetRoleByIdResponse>("Role not found");
            var MappedRole = _mapper.Map<GetRoleByIdResponse>(role);
            return Success(MappedRole);
        }

        public async Task<Response<ManageUserRoleResponse>> Handle(ManageUserRoleRequest request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null) return NotFound<ManageUserRoleResponse>("UserNotFound");
            var Result = await _authorizationService.ManageUserRoleAsync(User);
            return Success(Result);

        }

        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsRequest request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null) return NotFound<ManageUserClaimsResponse>("UserNotFound");
            var Result = await _authorizationService.ManageUserClaimsAsync(User);
            return Success(Result);
        }
    }
}
