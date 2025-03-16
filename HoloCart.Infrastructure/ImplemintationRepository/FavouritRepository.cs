using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class FavouritRepository : GenericRepositoryAsync<Favourite>, IFavouritRepository
    {
        private readonly DbSet<Favourite> _favourites;

        public FavouritRepository(AppDbContext dbContext) : base(dbContext)
        {

            _favourites = dbContext.Set<Favourite>();
        }
    }
}
