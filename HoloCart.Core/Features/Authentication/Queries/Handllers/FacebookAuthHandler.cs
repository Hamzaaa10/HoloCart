namespace HoloCart.Core.Features.Authentication.Queries.Handllers
{
    /* public class FacebookAuthHandler : IRequestHandler<FacebookAuthRequest, string>
     {
         private readonly IHttpContextAccessor _httpContextAccessor;
         private readonly JwtTokenService _jwtTokenService;

         public FacebookAuthHandler(IHttpContextAccessor httpContextAccessor, JwtTokenService jwtTokenService)
         {
             _httpContextAccessor = httpContextAccessor;
             _jwtTokenService = jwtTokenService;
         }

         public async Task<string> Handle(FacebookAuthRequest request, CancellationToken cancellationToken)
         {
             var result = await _httpContextAccessor.HttpContext.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);
             if (!result.Succeeded)
             {
                 return "Authentication failed";
             }

             var claims = result.Principal.Identities.FirstOrDefault()?.Claims;
             var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
             var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

             if (string.IsNullOrEmpty(email))
             {
                 return "Email not found";
             }

             // Generate JWT Token
             return _jwtTokenService.GenerateToken(email, name);
         }
     }*/
}