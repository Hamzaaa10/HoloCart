using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        [InverseProperty(nameof(UserRefreshToken.applicationuser))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
