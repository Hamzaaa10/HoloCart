using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class ApplicationUserRepository : GenericRepositoryAsync<ApplicationUser>, IApplicationUserRepository
    {
        private readonly DbSet<ApplicationUser> _applicationUsers;

        public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
        {

            _applicationUsers = dbContext.Set<ApplicationUser>();
        }
    }
}
