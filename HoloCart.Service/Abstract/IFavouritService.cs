using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IFavouritService
    {
        public Task<bool> IsProductInFavourit(int productId, int UserId);
        public Task<string> AddToFavouritesAsync(Favourite favourite);
        public Task<string> DeleteFavouritesAsync(int productId, int UserId);
        public Task<List<Favourite>> GetAllFavouritProducts(int UserId);
        public Task<List<int>> GetUserFavoriteProductIdsAsync(int userId);


    }
}
