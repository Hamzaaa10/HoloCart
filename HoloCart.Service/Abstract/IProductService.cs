using HoloCart.Data.Entities;
using HoloCart.Data.Enums.Product;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Service.Abstract
{
    public interface IProductService
    {
        public Task<string> AddProductAsync(Product product, IFormFile formFile);
        public Task<string> UpdateProductAsync(int id, Product product, IFormFile formFile);
        public Task<Product> GetByIdAcync(int id);
        public Task<string> DeleteProductAsync(int id);
        public Task<Product> GetProductByIdIncluded(int id);
        public IQueryable<Product> GetProductsQuarable(string Search, ProductOrderingEnum OrderBy);
        public IQueryable<Product> GetProductsByCategoryQuarable(int DID, string Search, ProductOrderingEnum OrderBy);
        public IQueryable<Product> GetProductsByDiscountQuarable(Decimal Percentage, string Search);

    }
}
