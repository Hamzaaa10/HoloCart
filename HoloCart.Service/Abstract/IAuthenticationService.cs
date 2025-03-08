using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace HoloCart.Service.Abstract
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResponse> GetJWTtoken(ApplicationUser user);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<JwtAuthResponse> GetRefreshToken(ApplicationUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
        public Task<string> ConfirmEmail(int UserId, string code);
        public Task<string> SendResetPasswordCode(string Email);
        public Task<string> ConfirmResetPassword(string Email, string code);
        public Task<string> ResetPassword(string Email, string Password);

    }
}
