using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Responses;

namespace HoloCart.Service.Abstract
{
    public interface IAuthorizationService
    {
        public Task<bool> IsRoleExistsByName(string RoleName);
        public Task<string> AddRoleAsync(string RoleName);
        public Task<string> RemoveRoleAsync(int id);
        public Task<string> UpdateRoleAsync(int id, string RoleName);
        public Task<List<ApplicationRole>> GetAllRolesAsync();
        public Task<ApplicationRole> GetRoleByIdAsync(int id);
        public Task<ManageUserRoleResponse> ManageUserRoleAsync(ApplicationUser user);
        public Task<ManageUserClaimsResponse> ManageUserClaimsAsync(ApplicationUser user);
        public Task<string> UpdateUserRoles(ManageUserRoleResponse request);
        public Task<string> UpdateUserClaims(ManageUserClaimsResponse request);
    }
}
