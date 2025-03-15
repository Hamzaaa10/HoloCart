using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class DiscountRepository : GenericRepositoryAsync<Discount>, IDiscountRepository
    {
        private readonly DbSet<Discount> _discounts;

        public DiscountRepository(AppDbContext dbContext) : base(dbContext)
        {

            _discounts = dbContext.Set<Discount>();
        }
    }
}
