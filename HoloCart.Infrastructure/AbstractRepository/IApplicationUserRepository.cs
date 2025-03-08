using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure.Bases;

namespace HoloCart.Infrastructure.AbstractRepository
{
    public interface IApplicationUserRepository : IGenericRepositoryAsync<ApplicationUser>
    {
    }
}
