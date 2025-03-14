using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {

            _categories = dbContext.Set<Category>();
        }
    }
}
