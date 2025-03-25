using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IDiscountRepository _discountRepository;

        public CartService(ICartRepository cartRepository, IDiscountRepository discountRepository)
        {
            _cartRepository = cartRepository;
            _discountRepository = discountRepository;
        }

        public async Task<string> ApplyDiscountOnCartValidation(int UserId, string discountCode)
        {
            var cart = await _cartRepository.GetTableAsTracking()
         .Include(c => c.CartItems)
         .ThenInclude(ci => ci.Product)
         .FirstOrDefaultAsync(x => x.ApplicationUserId == UserId);

            if (cart == null || !cart.CartItems.Any())
                return "NotFound";

            // Validate discount code
            var validateDiscountCode = await _discountRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(d => d.Code == discountCode &&
                                          d.StartDate <= DateTime.UtcNow &&
                                          d.EndDate >= DateTime.UtcNow);

            if (validateDiscountCode == null)
                return "CodeIsNotValid";

            // Calculate total after applying product-specific discounts
            var cartTotal = cart.CartItems.Sum(item =>
            {
                var productPrice = item.Product.BasePrice;

                // Apply product discount if available
                if (item.Product.Discount != null &&
                    DateTime.UtcNow >= item.Product.Discount.StartDate &&
                    DateTime.UtcNow <= item.Product.Discount.EndDate)
                {
                    productPrice -= productPrice * (item.Product.Discount.Percentage / 100);
                }

                return productPrice * item.Quantity;
            });

            // Calculate cart discount
            var discountAmount = cartTotal * (validateDiscountCode.Percentage / 100);

            // Apply discount
            cart.DiscountCode = validateDiscountCode.Code;
            cart.DiscountPercentage = validateDiscountCode.Percentage;  // Ensure your `Cart` entity has `DiscountAmount`

            await _cartRepository.UpdateAsync(cart);
            return "Success";

        }

        public async Task<string> CreateCartAsync(Cart cart)
        {
            var existingReview =
                await _cartRepository.GetTableNoTracking().Where(r => r.ApplicationUserId == cart.ApplicationUserId).FirstOrDefaultAsync();

            if (existingReview != null)
            {
                return "UserAlreadyHaveCart";
            }
            try
            {
                await _cartRepository.AddAsync(cart);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<Cart> GetCartByIdAsync(int CartId)
        {
            return await _cartRepository.GetByIdAsync(CartId);
        }

        public async Task<Cart> GetCartByUserIdAsync(int UserId)
        {


            var Cart = await _cartRepository.GetTableNoTracking()
                                  .Where(x => x.ApplicationUserId == UserId).
                                  Include(x => x.CartItems).ThenInclude(x => x.Product).ThenInclude(x => x.Discount).FirstOrDefaultAsync();
            return Cart;
        }

        public async Task<string> RemoveCartAsync(int CartId)
        {
            var cart = await _cartRepository.GetByIdAsync(CartId);
            if (cart == null) return "NotFound";

            try
            {
                await _cartRepository.DeleteAsync(cart);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }
        }
    }
}
