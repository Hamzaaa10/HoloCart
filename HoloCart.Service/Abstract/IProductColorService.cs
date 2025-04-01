using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IProductColorService
    {
        public Task<string> AddProductColorAsync(ProductColor productColor);
        public Task<string> UpdateProductColorAsync(ProductColor productColor);
        public Task<string> DeleteProductColorAsync(int id);
        public Task<ProductColor> GetProductColorById(int id);
        public Task<List<ProductColor>> GetAllProductColorsAcync(int ProductId);
    }
}
