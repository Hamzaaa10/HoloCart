using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepositry _cartItemRepository;


        public CartItemService(ICartItemRepositry cartItemRepositry)
        {
            _cartItemRepository = cartItemRepositry;
        }

        public async Task<string> AddCartItemAsync(CartItem cartItem)
        {
            var existingCartItem =
                           await _cartItemRepository.GetTableNoTracking().Where(r => r.ProductId == cartItem.ProductId && r.CartId == cartItem.CartId).FirstOrDefaultAsync();

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartItem.Quantity;
                UpdateCartItemAsync(existingCartItem);
                return "ProductisAlreadyinCart";
            }
            try
            {
                await _cartItemRepository.AddAsync(cartItem);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<CartItem> GetCartItemByIdAcync(int cartItemId)
        {
            return await _cartItemRepository.GetByIdAsync(cartItemId);
        }

        public async Task<string> RemoveCartItemAsync(int CartItemId)
        {
            var cart = await _cartItemRepository.GetByIdAsync(CartItemId);
            if (cart == null) return "NotFound";

            try
            {
                await _cartItemRepository.DeleteAsync(cart);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }

        }

        public async Task<string> UpdateCartItemAsync(CartItem cartItem)
        {
            try
            {
                await _cartItemRepository.UpdateAsync(cartItem);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }
    }
}
