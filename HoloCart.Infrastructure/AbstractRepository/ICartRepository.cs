using HoloCart.Data.Entities;
using HoloCart.Infrastructure.Bases;

namespace HoloCart.Infrastructure.AbstractRepository
{
    public interface ICartRepository : IGenericRepositoryAsync<Cart>
    {
    }
}
