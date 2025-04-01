using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class ProductColorService : IProductColorService
    {
        private readonly IProductColorRepository _productColorRepository;

        public ProductColorService(IProductColorRepository productColorRepository)
        {
            _productColorRepository = productColorRepository;
        }
        public async Task<string> AddProductColorAsync(ProductColor productColor)
        {
            try
            {
                await _productColorRepository.AddAsync(productColor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<string> DeleteProductColorAsync(int id)
        {
            var productColor = await _productColorRepository.GetByIdAsync(id);
            if (productColor == null) return "NotFound";

            try
            {
                await _productColorRepository.DeleteAsync(productColor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }
        }

        public async Task<List<ProductColor>> GetAllProductColorsAcync(int productId)
        {
            return await _productColorRepository.GetTableNoTracking().Where(x => x.ProductId == productId).Include(x => x.Image).ToListAsync();
        }

        public async Task<ProductColor> GetProductColorById(int id)
        {
            return await _productColorRepository.GetTableNoTracking().Where(x => x.ProductColorId == id).Include(x => x.Image).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateProductColorAsync(ProductColor productColor)
        {
            try
            {
                await _productColorRepository.UpdateAsync(productColor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }
    }
}
