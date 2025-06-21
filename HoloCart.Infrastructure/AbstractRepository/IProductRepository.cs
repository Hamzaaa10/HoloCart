using HoloCart.Data.Entities;
using HoloCart.Infrastructure.Bases;

namespace HoloCart.Infrastructure.AbstractRepository
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
        Task<Product?> GetLastAddedProductAsync();

    }
}
