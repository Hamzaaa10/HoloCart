using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authentication.Commands.Requests;
using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Responses;
using HoloCart.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Core.Features.Authentication.Commands.Handllers
{
    public class AuthenticationCommandHundller : ResponseHandller,
         IRequestHandler<SignInRequest, Response<JwtAuthResponse>>,
         IRequestHandler<RefreshTokenRequest, Response<JwtAuthResponse>>,
         IRequestHandler<SendResetPasswordRequest, Response<string>>,
         IRequestHandler<ResetPasswordRequest, Response<string>>



    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticationCommandHundller(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthenticationService authenticationService, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _roleManager = roleManager;
        }

        public async Task<Response<JwtAuthResponse>> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Email == request.Identifier || u.UserName == request.Identifier);
            if (user == null) return NotFound<JwtAuthResponse>("No user found such that username");
            var SignInResult = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!SignInResult) return BadRequest<JwtAuthResponse>("PasswordNotCorrect");
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResponse>("EmailNotConfirmed");

            var accesstoken = await _authenticationService.GetJWTtoken(user);
            return Success(accesstoken);

        }

        public async Task<Response<JwtAuthResponse>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJWTToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResponse>("Algorithm Is Wrong");
                case ("TokenIsValid", null): return Unauthorized<JwtAuthResponse>("Token Is Valid");
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResponse>("RefreshToken Is Not Found");
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResponse>("RefreshToken Is Expired");
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResponse>();
            }
            var result = await _authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SendResetPasswordCode(request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserIsNotFound");
                case "ErrorInUpdateUser": return BadRequest<string>("TryAgainInAnotherTime");
                case "Failed": return BadRequest<string>("TryAgainInAnotherTime");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("TryAgainInAnotherTime");
            }
        }

        public async Task<Response<string>> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ResetPassword(request.Email, request.Password);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserIsNotFound");
                case "Failed": return BadRequest<string>("InvalidCode");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("InvalidCode");
            }
        }
    }
}
