using HoloCart.Data.Entities.Identity;
using HoloCart.Data.Helpers;
using HoloCart.Data.Responses;
using HoloCart.Infrastructure.Context;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HoloCart.Service.Implemintation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _dbContext;

        public AuthorizationService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> AddRoleAsync(string RoleName)
        {
            var Role = new ApplicationRole()
            {
                Name = RoleName,
            };
            var result = await _roleManager.CreateAsync(Role);
            if (result.Succeeded) return "Success";
            return "Failed";
        }

        public async Task<List<ApplicationRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<ApplicationRole> GetRoleByIdAsync(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<bool> IsRoleExistsByName(string RoleName)
        {
            return await _roleManager.RoleExistsAsync(RoleName) == null ? true : false;
        }

        public async Task<ManageUserClaimsResponse> ManageUserClaimsAsync(ApplicationUser user)
        {
            var UserClaims = await _userManager.GetClaimsAsync(user);
            var response = new ManageUserClaimsResponse();
            var AllUserClaim = new List<claim>();
            foreach (var claim in ClaimsStore.Claims)
            {
                var Claim = new claim();
                Claim.Type = claim.Type;
                Claim.Value = UserClaims.Any(x => x.Type == claim.Type) ? true : false;
                AllUserClaim.Add(Claim);
            }
            response.UserId = user.Id;
            response.Claims = AllUserClaim;
            return response;
        }

        public async Task<ManageUserRoleResponse> ManageUserRoleAsync(ApplicationUser user)
        {
            var AllRoles = await _roleManager.Roles.ToListAsync();
            ManageUserClaimsResponse AllUserRoles;
            var response = new ManageUserRoleResponse();
            var Roles = new List<Role>();
            foreach (var role in AllRoles)
            {
                var Role = new Role();
                Role.Id = role.Id;
                Role.Name = role.Name;
                Role.HasRole = await _userManager.IsInRoleAsync(user, role.Name) ? true : false;
                Roles.Add(Role);
            }
            response.UserId = user.Id;
            response.Roles = Roles;
            return response;
        }

        public async Task<string> RemoveRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return "NotFound";

            var Useres = await _userManager.GetUsersInRoleAsync(role.Name);
            if (Useres != null && Useres.Count() > 0) return "Used";
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

        public async Task<string> UpdateRoleAsync(int id, string RoleName)
        {
            var Role = await _roleManager.FindByIdAsync(id.ToString());
            if (Role == null) return "NotFound";
            Role.Name = RoleName;
            var result = await _roleManager.UpdateAsync(Role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }
        public async Task<string> UpdateUserClaims(ManageUserClaimsResponse request)
        {
            /*var transact = await _dbContext.Database.BeginTransactionAsync();
            try
            {*/
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return "UserIsNull";
            }
            var UserClaims = await _userManager.GetClaimsAsync(user);
            var RemoveResult = await _userManager.RemoveClaimsAsync(user, UserClaims);
            if (!RemoveResult.Succeeded)
                return "FailedToRemoveOldClaims";
            var SelectedClaims = request.Claims.Where(x => x.Value == true).Select(x => new Claim(type: x.Type, value: x.Value.ToString()));
            var AddResult = await _userManager.AddClaimsAsync(user, SelectedClaims);
            if (!AddResult.Succeeded)
                return "FailedToAddNewClaims";

            //  await transact.CommitAsync();

            return "Success";
            /* }

             catch (Exception ex)
             {
                 await transact.RollbackAsync();
                 return "FailedToUpdateUserRoles";
             }*/
        }

        public async Task<string> UpdateUserRoles(ManageUserRoleResponse request)
        {
            //  var transact = await _dbContext.Database.BeginTransactionAsync();

            //Get User
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return "UserIsNull";
            }
            //get user Old Roles
            var userRoles = await _userManager.GetRolesAsync(user);
            //Delete OldRoles
            var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!removeResult.Succeeded)
                return "FailedToRemoveOldRoles";
            var selectedRoles = request.Roles.Where(x => x.HasRole == true).Select(x => x.Name);

            //Add the Roles HasRole=True
            var addRolesresult = await _userManager.AddToRolesAsync(user, selectedRoles);
            if (!addRolesresult.Succeeded)
                return "FailedToAddNewRoles";
            //  await transact.CommitAsync();
            //return Result
            return "Success";
        }
        /* catch (Exception ex)
         {
             await transact.RollbackAsync();
             return "FailedToUpdateUserRoles";
         }*/
    }
}




