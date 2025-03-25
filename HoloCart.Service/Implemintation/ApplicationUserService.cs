using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Context;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ApplicationUserService(UserManager<ApplicationUser> userManager,
                                      IApplicationUserRepository applicationUserRepository,
                                      AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor,
                                      IEmailService emailsService,
                                      IUrlHelper urlHelper,

            IFileService fileService,
            IWebHostEnvironment webHostEnvironment
)
        {
            _userManager = userManager;
            _applicationUserRepository = applicationUserRepository;
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _urlHelper = urlHelper;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<string> UpdateUserAsync(ApplicationUser user, IFormFile file)
        {

            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            if (file != null && file.Length > 0)
            {
                // **Delete old image if exists**
                if (!string.IsNullOrEmpty(user.ProfileImage))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        user.ProfileImage.Replace(baseUrl, "").TrimStart('/'));

                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                var imageUrl = await _fileService.UploadImage("Users", file);
                switch (imageUrl)
                {
                    case "NoImage": return "NoImage";
                    case "FailedToUploadImage": return "FailedToUploadImage";
                }
                user.ProfileImage = baseUrl + imageUrl;
            }
            else
            {
                user.ProfileImage = user.ProfileImage; // Retain old image if no new file
            }
            try
            {
                await _userManager.UpdateAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
                //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                //message or body
                await _emailsService.SendEmailAsync(user.Email, message, "ConFirm Email");
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }

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
