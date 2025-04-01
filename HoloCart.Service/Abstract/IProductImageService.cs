using HoloCart.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Service.Abstract
{
    public interface IProductImageService
    {
        public Task<string> AddProductAsync(ProductImage productImage, IFormFile file);
        public Task<string> UpdateProductAsync(int id, ProductImage productImage, IFormFile file);
        public Task<string> DeleteProductAsync(int id);
        public Task<ProductImage> GetProductImageById(int id);


    }
}
