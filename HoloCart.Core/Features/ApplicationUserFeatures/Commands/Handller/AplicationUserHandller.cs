using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests;
using HoloCart.Data.Entities.Identity;
using HoloCart.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands
{
    public class AplicationUserHandller : ResponseHandller,
                     IRequestHandler<AddAplicationUserRequest, Response<string>>,
                     IRequestHandler<UpdateAplicationUserRequest, Response<string>>,
                     IRequestHandler<DeleteAplicationUserRequest, Response<string>>,
                     IRequestHandler<ChangePasswordRequest, Response<string>>


    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AplicationUserHandller(UserManager<ApplicationUser> userManager, IMapper mapper, IApplicationUserService applicationUserService)
        {
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            this._userManager = userManager;
        }
        public async Task<Response<string>> Handle(AddAplicationUserRequest request, CancellationToken cancellationToken)
        {
            var NewUser = _mapper.Map<ApplicationUser>(request);
            var Result = await _applicationUserService.AddUserAsync(NewUser, request.Password);
            switch (Result)
            {
                case "Success": return Success<string>(" User Aded successfully");
                case "Failed": return BadRequest<string>("TryToRegisterAgain");
                default: return BadRequest<string>(Result);
            }

        }

        public async Task<Response<string>> Handle(UpdateAplicationUserRequest request, CancellationToken cancellationToken)
        {
            var OldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (OldUser == null) return NotFound<string>("this user doesn't exists");
            var NewUser = _mapper.Map(request, OldUser);
            var Result = await _applicationUserService.UpdateUserAsync(NewUser, request.ProfileImage);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInUpdate": return BadRequest<string>("FailedInUpdate");
            }
            return Success("User Updated Successufully");

        }

        public async Task<Response<string>> Handle(DeleteAplicationUserRequest request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.id.ToString());
            if (User == null) return NotFound<string>("this user doesn't exists");
            var Result = await _userManager.DeleteAsync(User);
            if (!Result.Succeeded) return BadRequest<string>(Result.Errors.FirstOrDefault().Description);
            return Success("Deleted Succsessfully");
        }

        public async Task<Response<string>> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null) return NotFound<string>("this user don't exists");
            var result = await _userManager.ChangePasswordAsync(User, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success("changed");
        }
    }
}
