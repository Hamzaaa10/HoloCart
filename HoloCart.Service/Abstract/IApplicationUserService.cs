using HoloCart.Data.Entities.Identity;

namespace HoloCart.Service.Abstract
{
    public interface IApplicationUserService
    {
        public Task<bool> IsEmailExists(string Email);
        public Task<bool> IsEmailExistsExcludeYourself(int id, string Email);
        public Task<bool> IsUserNameExists(string UserName);
        public Task<bool> IsUserNameExistsExcludeYourself(int id, string UserName);
        public Task<string> AddUserAsync(ApplicationUser user, string password);

    }
}
