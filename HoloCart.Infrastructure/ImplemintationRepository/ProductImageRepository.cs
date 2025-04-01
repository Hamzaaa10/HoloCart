using HoloCart.Data.Entities;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    internal class ProductImageRepository : GenericRepositoryAsync<ProductImage>, IProductImageRepository
    {
        private readonly DbSet<ProductImage> _productImages;

        public ProductImageRepository(AppDbContext dbContext) : base(dbContext)
        {

            _productImages = dbContext.Set<ProductImage>();
        }
    }
}