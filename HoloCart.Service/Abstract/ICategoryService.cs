using HoloCart.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Service.Abstract
{
    public interface ICategoryService
    {
        public Task<Category> GetByIdAcync(int id);
        public Task<List<Category>> GetDepartmentsAcync();
        public Task<bool> IsCategoryNameExists(string Name);
        public Task<bool> IsCategoryNameExistsExcloud(string Name, int id);
        public Task<string> AddCategoryAsync(Category category, IFormFile formFile);
        public Task<string> DeleteCategoryAsync(int id);
        public Task<string> UpdateCategoryAsync(int id, Category category, IFormFile formFile);



    }
}
