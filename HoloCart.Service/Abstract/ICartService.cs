using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface ICartService
    {
        public Task<string> CreateCartAsync(Cart cart);
        public Task<Cart> GetCartByUserIdAsync(int UserId);
        public Task<Cart> GetCartByIdAsync(int CartId);

        public Task<string> RemoveCartAsync(int CartId);
        public Task<string> ApplyDiscountOnCartValidation(int UserId, string code);


    }
}
