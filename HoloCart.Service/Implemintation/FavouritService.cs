using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class FavouritService : IFavouritService
    {
        private readonly IFavouritRepository _favouritRepository;

        public FavouritService(IFavouritRepository favouritRepository)
        {
            _favouritRepository = favouritRepository;
        }

        public async Task<string> AddToFavouritesAsync(Favourite favourite)
        {
            try
            {
                await _favouritRepository.AddAsync(favourite);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<string> DeleteFavouritesAsync(int productId, int UserId)
        {
            var favourit = await _favouritRepository.GetTableNoTracking().Where(x => x.ApplicationUserId == UserId && x.ProductId == productId).FirstOrDefaultAsync();
            if (favourit == null) return "NotInFavourit";
            try
            {
                await _favouritRepository.DeleteAsync(favourit);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }
        }

        public async Task<List<Favourite>> GetAllFavouritProducts(int UserId)
        {
            var FavouritProducts = await _favouritRepository.GetTableNoTracking().Where(x => x.ApplicationUserId == UserId).Include(x => x.Product).ToListAsync();
            return FavouritProducts;
        }

        public async Task<List<int>> GetUserFavoriteProductIdsAsync(int userId)
        {
            return await _favouritRepository.GetTableNoTracking()
                        .Where(f => f.ApplicationUserId == userId)
                        .Select(f => f.ProductId)
                        .ToListAsync();
        }

        public async Task<bool> IsProductInFavourit(int productId, int UserId)
        {
            return await _favouritRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ApplicationUserId == UserId && x.ProductId == productId) == null ? false : true;
        }

    }
}
