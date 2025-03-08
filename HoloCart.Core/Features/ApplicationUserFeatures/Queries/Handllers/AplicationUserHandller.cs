using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Requests;
using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Responses;
using HoloCart.Core.Wrappers;
using HoloCart.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Queries.Handllers
{
    public class AplicationUserHandller : ResponseHandller, IRequestHandler<GetApplicationUserByIdRequest, Response<GetApplicationUserByIdResponse>>
                                                          , IRequestHandler<GetApplicationUsersPaginatedRequest, PaginatedResult<GetApplicationUserPaginatedResponse>>


    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AplicationUserHandller(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<Response<GetApplicationUserByIdResponse>> Handle(GetApplicationUserByIdRequest request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null) return NotFound<GetApplicationUserByIdResponse>($"User with id {request.Id} is not found ");
            var result = _mapper.Map<GetApplicationUserByIdResponse>(User);
            return Success(result);
        }

        public async Task<PaginatedResult<GetApplicationUserPaginatedResponse>> Handle(GetApplicationUsersPaginatedRequest request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedUsers = await _mapper.ProjectTo<GetApplicationUserPaginatedResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedUsers;
        }
    }
}
