using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        private readonly DbSet<UserRefreshToken> _userRefreshTokens;

        public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
        {

            _userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
    }
}
