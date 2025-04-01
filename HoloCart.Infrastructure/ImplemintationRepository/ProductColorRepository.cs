using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class ProductColorRepository : GenericRepositoryAsync<ProductColor>, IProductColorRepository
    {
        private readonly DbSet<ProductColor> _productColors;

        public ProductColorRepository(AppDbContext dbContext) : base(dbContext)
        {

            _productColors = dbContext.Set<ProductColor>();
        }
    }
}