using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authorization.Commands.Requests;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Handllers
{
    public class ClaimCommandHundller : ResponseHandller,
                                                   IRequestHandler<UpdateUserClaimRequest, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public ClaimCommandHundller(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(UpdateUserClaimRequest request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("UserIsNotFound");
                case "FailedToRemoveOldClaims": return BadRequest<string>("FailedToRemoveOldClaims");
                case "FailedToAddNewClaims": return BadRequest<string>("FailedToAddNewClaims");
                case "FailedToUpdateUserClaims": return BadRequest<string>("FailedToUpdateUserClaims");
            }
            return Success<string>("Success");

        }
    }
}
