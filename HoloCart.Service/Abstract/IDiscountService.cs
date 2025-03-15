using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IDiscountService
    {
        public Task<bool> IsDiscountCodeExists(string Code);
        public Task<bool> IsDiscountCodeExistsExclude(string Code, int id);
        public Task<string> AddDiscountAsync(Discount discount);
        public Task<string> UpdateDiscountAsync(Discount discount);
        public Task<string> DeleteDiscountAsync(int id);
        public Task<Discount> GetDiscountById(int id);
        public Task<List<Discount>> GetAllDiscountsAcync();




    }
}
