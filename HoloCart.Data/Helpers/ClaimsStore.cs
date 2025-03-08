using System.Security.Claims;

namespace HoloCart.Data.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> Claims = new()
        {
        new Claim("Create User","false"),
        new Claim("Edit User","false"),
        new Claim("Delete User","false")
        };
    }
}
