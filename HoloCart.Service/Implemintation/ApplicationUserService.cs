using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Context;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailsService;
        private readonly IUrlHelper _urlHelper;

        public ApplicationUserService(UserManager<ApplicationUser> userManager,
                                      IApplicationUserRepository applicationUserRepository,
                                      AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor,
                                      IEmailService emailsService,
                                      IUrlHelper urlHelper
)
        {
            _userManager = userManager;
            _applicationUserRepository = applicationUserRepository;
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _urlHelper = urlHelper;
        }
        public async Task<string> AddUserAsync(ApplicationUser user, string password)
        {
            var trans = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var createResult = await _userManager.CreateAsync(user, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                await _userManager.AddToRoleAsync(user, "ApplicationUser");

                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
                //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                //message or body
                await _emailsService.SendEmailAsync(user.Email, message, "ConFirm Email");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }



        public async Task<bool> IsEmailExistsExcludeYourself(int id, string Email)
        {
            return await _applicationUserRepository.GetTableNoTracking().Where(x => x.Email == Email && x.Id != id).FirstOrDefaultAsync() == null ? false : true;
        }

        public async Task<bool> IsUserNameExistsExcludeYourself(int id, string UserName)
        {
            return await _applicationUserRepository.GetTableNoTracking().Where(x => x.UserName == UserName && x.Id != id).FirstOrDefaultAsync() == null ? false : true;
        }

        async Task<bool> IApplicationUserService.IsEmailExists(string Email)
        {
            return await _userManager.FindByEmailAsync(Email) == null ? false : true;
        }

        async Task<bool> IApplicationUserService.IsUserNameExists(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName) == null ? false : true;
        }
    }
}
