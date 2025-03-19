using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class ReviewRepository : GenericRepositoryAsync<Review>, IReviewRepository
    {
        private readonly DbSet<Review> _reviews;

        public ReviewRepository(AppDbContext dbContext) : base(dbContext)
        {

            _reviews = dbContext.Set<Review>();
        }
    }
}



