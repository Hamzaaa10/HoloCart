using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface ICartItemService
    {
        public Task<string> AddCartItemAsync(CartItem cartItem);
        public Task<CartItem> GetCartItemByIdAcync(int cartItemId);
        public Task<string> UpdateCartItemAsync(CartItem cartItem);
        public Task<string> RemoveCartItemAsync(int CartItemId);




    }
}
