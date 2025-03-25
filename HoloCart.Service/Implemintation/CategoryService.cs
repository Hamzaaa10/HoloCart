using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryService(ICategoryRepository categoryRepository,
            IHttpContextAccessor httpContextAccessor,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> AddCategoryAsync(Category category, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Categories", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            category.CategoryImage = baseUrl + imageUrl;
            try
            {
                await _categoryRepository.AddAsync(category);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<string> DeleteCategoryAsync(int id)
        {
            var Category = await _categoryRepository.GetTableNoTracking().Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            if (Category == null) return "NotFound";
            await _categoryRepository.DeleteAsync(Category);
            return "Success";
        }

        public async Task<Category> GetByIdAcync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetDepartmentsAcync()
        {
            return await _categoryRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<bool> IsCategoryNameExists(string Name)
        {
            return await _categoryRepository.GetTableNoTracking().Where(x => x.Name == Name).FirstOrDefaultAsync() == null ? false : true;
        }

        public async Task<bool> IsCategoryNameExistsExcloud(string Name, int id)
        {
            return await _categoryRepository.GetTableNoTracking().Where(x => x.Name == Name && x.CategoryId != id).FirstOrDefaultAsync() == null ? false : true;
        }

        public async Task<string> UpdateCategoryAsync(Category category, IFormFile file)
        {

            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            if (file != null && file.Length > 0)
            {
                // **Delete old image if exists**
                if (!string.IsNullOrEmpty(category.CategoryImage))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        category.CategoryImage.Replace(baseUrl, "").TrimStart('/'));

                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                var imageUrl = await _fileService.UploadImage("Categories", file);
                switch (imageUrl)
                {
                    case "NoImage": return "NoImage";
                    case "FailedToUploadImage": return "FailedToUploadImage";
                }
                category.CategoryImage = baseUrl + imageUrl;
            }
            else
            {
                category.CategoryImage = category.CategoryImage; // Retain old image if no new file
            }
            try
            {
                await _categoryRepository.UpdateAsync(category);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }


        }
    }
}

