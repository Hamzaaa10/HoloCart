using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<string> AddDiscountAsync(Discount discount)
        {
            try
            {
                await _discountRepository.AddAsync(discount);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<string> DeleteDiscountAsync(int id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);
            if (discount == null) return "NotFound";

            try
            {
                await _discountRepository.DeleteAsync(discount);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }

        }

        public async Task<List<Discount>> GetAllDiscountsAcync()
        {
            return await _discountRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            return await _discountRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsDiscountCodeExists(string code)
        {
            return await _discountRepository.GetTableNoTracking().Where(x => x.Code == code).FirstOrDefaultAsync() == null ? false : true;
        }

        public async Task<bool> IsDiscountCodeExistsExclude(string Code, int id)
        {
            return await _discountRepository.GetTableNoTracking().Where(x => x.Code == Code && x.DiscountId != id).FirstOrDefaultAsync() == null ? false : true;
        }

        public async Task<string> UpdateDiscountAsync(Discount discount)
        {
            try
            {
                await _discountRepository.UpdateAsync(discount);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }
    }
}
