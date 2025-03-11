using Google.Apis.Auth;
using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Helpers;
using HoloCart.Data.Responses;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Context;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HoloCart.Service.Implemintation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Jwtsettings _jwtsettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDBContext;
        private readonly IEmailService _emailService;
        private readonly ExternalAuthenticationSetting _externalAuthenticationSetting;
        private readonly HttpClient _httpClient;


        // private readonly IEncryptionProvider _encryptionProvider;


        public AuthenticationService(Jwtsettings jwtsettings,
            IRefreshTokenRepository refreshTokenRepository,
            UserManager<ApplicationUser> userManager,
            AppDbContext appDBContext,
            IEmailService emailService,
            ExternalAuthenticationSetting externalAuthenticationSetting,
            HttpClient httpClient)
        {
            _jwtsettings = jwtsettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _appDBContext = appDBContext;
            _emailService = emailService;
            _externalAuthenticationSetting = externalAuthenticationSetting;
            _httpClient = httpClient;
        }
        public async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var UserClaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>() {
                new Claim(nameof(UserClaimsModel.Email), user.Email)  ,
                new Claim(nameof(UserClaimsModel.UserName), user.UserName),
                new Claim(nameof(UserClaimsModel.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimsModel.Id), user.Id.ToString())
                };
            claims.AddRange(UserClaims);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private string GeneratetRefreshToken()
        {

            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            var refreshToken = Convert.ToBase64String(randomNumber);
            return refreshToken;
        }
        private RefreshToken GetRefreshToken(string username, string refreshToken)
        {

            var Refreshtoken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtsettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = refreshToken
            };

            return Refreshtoken;
        }
        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(ApplicationUser user)
        {
            var jwtToken = new JwtSecurityToken(
             issuer: _jwtsettings.Issuer,
             audience: _jwtsettings.Audience,
             claims: await GetClaims(user),
             notBefore: DateTime.Now,
             expires: DateTime.Now.AddMinutes(_jwtsettings.AccessTokenExpireDate),
             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
             );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        public async Task<JwtAuthResponse> GetJWTtoken(ApplicationUser user)
        {

            var (jwtToken, accessToken) = await GenerateJWTToken(user);
            var stringrefreshtoken = GeneratetRefreshToken();
            var userrefreshtoken = new UserRefreshToken
            {
                UserId = user.Id,
                JwtId = jwtToken.Id,
                IsRevoked = false,
                IsUsed = false,
                ExpiryDate = DateTime.UtcNow.AddDays(_jwtsettings.RefreshTokenExpireDate),
                AddedTime = DateTime.UtcNow,
                Token = accessToken,
                RefreshToken = stringrefreshtoken,
            };
            await _refreshTokenRepository.AddAsync(userrefreshtoken);


            var gwtResult = new JwtAuthResponse
            {
                AccessToken = accessToken,
                refreshToken = GetRefreshToken(user.UserName, stringrefreshtoken)
            };

            return (gwtResult);

        }
        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtsettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtsettings.Issuer },
                ValidateIssuerSigningKey = _jwtsettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings.Secret)),
                ValidAudience = _jwtsettings.Audience,
                ValidateAudience = _jwtsettings.ValidateAudience,
                ValidateLifetime = _jwtsettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "InvalidToken";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("AlgorithmIsWrong", null);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("TokenIsNotExpired", null);
            }

            //Get User

            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.Id)).Value;
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking()
                                             .FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                                     x.RefreshToken == refreshToken &&
                                                                     x.UserId == int.Parse(userId));
            if (userRefreshToken == null)
            {
                return ("RefreshTokenIsNotFound", null);
            }

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("RefreshTokenIsExpired", null);
            }
            var expirydate = userRefreshToken.ExpiryDate;
            return (userId, expirydate);
        }

        public async Task<JwtAuthResponse> GetRefreshToken(ApplicationUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {
            var (jwtSecurityToken, newaccessToken) = await GenerateJWTToken(user);
            var response = new JwtAuthResponse();
            var refreshTokenResult = new RefreshToken();
            response.AccessToken = newaccessToken;
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpireAt = (DateTime)expiryDate;
            response.refreshToken = refreshTokenResult;
            return response;

        }

        public async Task<string> ConfirmEmail(int UserId, string code)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
            if (!confirmEmail.Succeeded)
                return "ErrorWhenConfirmEmail";
            return "Success";
        }

        public async Task<string> SendResetPasswordCode(string Email)
        {
            var trans = await _appDBContext.Database.BeginTransactionAsync();
            try
            {
                var User = await _userManager.FindByEmailAsync(Email);
                if (User == null) return "UserNotFound";

                var chars = "0123456789";
                var random = new Random();
                var Code = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                User.Code = Code;
                var UpdateResult = await _userManager.UpdateAsync(User);
                if (!UpdateResult.Succeeded) return "Error in Update User";
                string message = "Code for Reset Password  " + Code;
                await _emailService.SendEmailAsync(Email, message, "ResetPassword");
                await trans.CommitAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> ConfirmResetPassword(string Email, string code)
        {
            var User = await _userManager.FindByEmailAsync(Email);
            if (User == null) return "UserNotFound";
            if (code != User.Code) return "failed";
            return "Success";

        }

        public async Task<string> ResetPassword(string Email, string Password)
        {
            var trans = await _appDBContext.Database.BeginTransactionAsync();
            try
            {
                //Get User
                var user = await _userManager.FindByEmailAsync(Email);
                //user not Exist => not found
                if (user == null)
                    return "UserNotFound";
                await _userManager.RemovePasswordAsync(user);
                if (!await _userManager.HasPasswordAsync(user))
                {
                    await _userManager.AddPasswordAsync(user, Password);
                }
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<JwtAuthResponse> LoginWithGoogle(string googleToken)
        {
            var payload = await VerifyGoogleToken(googleToken);
            if (payload == null)
                throw new Exception("Invalid Google Token");

            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = payload.Email, UserName = payload.Email };
                await _userManager.CreateAsync(user);
            }

            return await GetJWTtoken(user);
        }

        public async Task<JwtAuthResponse> LoginWithFacebook(string facebookToken)
        {
            var fbUser = await VerifyFacebookToken(facebookToken);
            if (fbUser == null)
                throw new Exception("Invalid Facebook Token");

            var user = await _userManager.FindByEmailAsync(fbUser.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = fbUser.Email, UserName = fbUser.Email };
                await _userManager.CreateAsync(user);
            }

            return await GetJWTtoken(user);
        }

        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new List<string> { _externalAuthenticationSetting.GoogleClientId }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            Console.WriteLine($"Token Audience: {string.Join(", ", payload.Audience)}");
            Console.WriteLine($"Expected Audience: {_externalAuthenticationSetting.GoogleClientId}");
            return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
        }

        private async Task<FacebookUserData> VerifyFacebookToken(string accessToken)
        {
            var url = $"https://graph.facebook.com/me?fields=id,name,email&access_token={accessToken}";
            var response = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<FacebookUserData>(response);
        }

        /* private async Task<JwtAuthResponse> GenerateJwtToken(ApplicationUser user)
         {
             // الكود الخاص بإنشاء JWT Token
             return new JwtAuthResponse
             {
                 Token = "GeneratedJWTToken",
                 Expiration = DateTime.UtcNow.AddHours(1)
             };
         }*/
    }
}



