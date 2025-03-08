using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authorization.Commands.Requests;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Handllers
{
    public class AuthorizationCommandHundller : ResponseHandller,
                IRequestHandler<AddRoleRequest, Response<string>>,
                IRequestHandler<UpdateRoleRequest, Response<string>>,
                IRequestHandler<DeleteRoleRequest, Response<string>>,
                IRequestHandler<UpdateUserRoleRequest, Response<string>>

    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationCommandHundller(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(AddRoleRequest request, CancellationToken cancellationToken)
        {
            var NewRole = await _authorizationService.AddRoleAsync(request.RoleName);
            if (NewRole == "Failed") return BadRequest<string>("Failed to add Role");
            return Created<string>("Role added");
        }

        public async Task<Response<string>> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateRoleAsync(request.Id, request.RoleName);
            if (result == "NotFound") return NotFound<string>($"Role with name {request.RoleName} was not found");
            else if (result == "Success") return Success<string>("edited successuflly");
            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRoleRequest request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("UserIsNotFound");
                case "FailedToRemoveOldRoles": return BadRequest<string>("FailedToRemoveOldRoles");
                case "FailedToAddNewRoles": return BadRequest<string>("FailedToAddNewRoles");
                case "FailedToUpdateUserRoles": return BadRequest<string>("FailedToUpdateUserRoles");
            }
            return Success<string>("Success");
        }

        async Task<Response<string>> IRequestHandler<DeleteRoleRequest, Response<string>>.Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.RemoveRoleAsync(request.Id);
            if (result == "NotFound") return NotFound<string>($"Role With id {request.Id} was not found");
            if (result == "Used") return BadRequest<string>(" there is some Users assign this role");
            else if (result == "Success") return Success<string>("Deleted successuflly");
            return BadRequest<string>(result);
        }
    }
}
