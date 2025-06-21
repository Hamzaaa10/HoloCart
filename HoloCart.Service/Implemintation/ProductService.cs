using HoloCart.Data.Entities;
using HoloCart.Data.Enums.Product;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IProductRepository productRepository,
            IHttpContextAccessor httpContextAccessor,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<(string Status, Product? Product)> AddProductAsync(Product product, IFormFile file, IFormFile? model)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;

            var imageUrl = await _fileService.UploadImage("Products", file);
            switch (imageUrl)
            {
                case "NoImage": return ("NoImage_Main", null);
                case "FailedToUploadImage": return ("FailedToUpload_Main", null);
            }
            product.MainImageUrl = baseUrl + imageUrl;

            if (model != null)
            {
                var modelUrl = await _fileService.UploadImage("Products/Models", model);
                switch (modelUrl)
                {
                    case "NoImage": return ("NoModel", null);
                    case "FailedToUploadImage": return ("FailedToUpload_Model", null);
                }
                product.Model = baseUrl + modelUrl;
            }

            try
            {
                await _productRepository.AddAsync(product);
                return ("Success", product); // ✅ return product
            }
            catch
            {
                return ("FailedInAdd", null);
            }
        }



        public async Task<string> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return "NotFound";

            var imageUrl = product.MainImageUrl;
            var deleteResult = await _fileService.DeleteImage(imageUrl);
            if (!deleteResult) return "FailedToDeleteImage";

            await _productRepository.DeleteAsync(product);
            return "Success";
        }

        public async Task<Product> GetByIdAcync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetProductByIdIncluded(int id)
        {
            return await _productRepository.GetTableNoTracking().Where(x => x.ProductId == id).Include(x => x.Category).Include(x => x.Discount).Include(x => x.Reviews).ThenInclude(x => x.User).Include(x => x.Colors).ThenInclude(x => x.Image).FirstOrDefaultAsync();
        }
        /* public async Task<List<Product>> GetAllProduc()
         {
             return await _productRepository.GetTableNoTracking().Include(x => x.Category).Include(x => x.Discount).Include(x => x.Colors).ThenInclude(x => x.Image).ToListAsync();
         }
 */
        public async Task<string> UpdateProductAsync(int id, Product product, IFormFile file, IFormFile model)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;

            // Handle image update
            if (file != null && file.Length > 0)
            {
                // Delete old image if exists
                if (!string.IsNullOrEmpty(product.MainImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        product.MainImageUrl.Replace(baseUrl, "").TrimStart('/'));

                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                var imageUrl = await _fileService.UploadImage("Products", file);
                switch (imageUrl)
                {
                    case "NoImage": return "NoImage_Main";
                    case "FailedToUploadImage": return "FailedToUpload_Main";
                }

                product.MainImageUrl = baseUrl + imageUrl;
            }

            // Handle model file update
            if (model != null && model.Length > 0)
            {
                // Delete old model file if exists
                if (!string.IsNullOrEmpty(product.Model))
                {
                    var oldModelPath = Path.Combine(_webHostEnvironment.WebRootPath,
                        product.Model.Replace(baseUrl, "").TrimStart('/'));

                    if (File.Exists(oldModelPath))
                    {
                        File.Delete(oldModelPath);
                    }
                }

                var modelUrl = await _fileService.UploadImage("Products/Models", model);
                switch (modelUrl)
                {
                    case "NoImage": return "NoModel";
                    case "FailedToUploadImage": return "FailedToUpload_Model";
                }

                product.Model = baseUrl + modelUrl;
            }

            try
            {
                await _productRepository.UpdateAsync(product);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }

        public IQueryable<Product> GetProductsQuarable(string Search, ProductOrderingEnum OrderBy)
        {
            var Quareble = _productRepository
                .GetTableNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Discount)
                .Include(x => x.Reviews)
                .AsQueryable();

            if (!string.IsNullOrEmpty(Search))
            {
                Quareble = Quareble.Where(x => x.Name.Contains(Search) || x.Description.Contains(Search));
            }

            switch (OrderBy)
            {
                case ProductOrderingEnum.EcsName:
                    Quareble = Quareble.OrderBy(x => x.Name);
                    break;
                case ProductOrderingEnum.DecsName:
                    Quareble = Quareble.OrderByDescending(x => x.Name);
                    break;
                case ProductOrderingEnum.FinalPrice:
                    Quareble = Quareble.OrderBy(x => x.BasePrice - (x.Discount != null ? (x.BasePrice * x.Discount.Percentage / 100) : 0)); // ✅ إصلاح مشكلة null
                    break;
                case ProductOrderingEnum.Discount:
                    Quareble = Quareble.OrderByDescending(x => x.Discount != null ? x.Discount.Percentage : 0);
                    break;
            }

            return Quareble;
        }

        public IQueryable<Product> GetProductsByCategoryQuarable(int DID, string Search, ProductOrderingEnum OrderBy)
        {
            var Quareble = _productRepository
                            .GetTableNoTracking()
                            .Where(x => x.CategoryId == DID)
                            .Include(x => x.Category)
                            .Include(x => x.Discount)
                            .Include(x => x.Reviews)
                            .AsQueryable();
            if (!string.IsNullOrEmpty(Search))
            {
                Quareble = Quareble.Where(x => x.Name.Contains(Search) || x.Description.Contains(Search));
            }
            switch (OrderBy)
            {
                case ProductOrderingEnum.EcsName:
                    Quareble = Quareble.OrderBy(x => x.Name);
                    break;
                case ProductOrderingEnum.DecsName:
                    Quareble = Quareble.OrderByDescending(x => x.Name);
                    break;
                case ProductOrderingEnum.FinalPrice:
                    Quareble = Quareble.OrderBy(x => x.BasePrice - (x.Discount != null ? (x.BasePrice * x.Discount.Percentage / 100) : 0)); // ✅ إصلاح مشكلة null
                    break;
                case ProductOrderingEnum.Discount:
                    Quareble = Quareble.OrderByDescending(x => x.Discount != null ? x.Discount.Percentage : 0);
                    break;
            }
            return Quareble;
        }

        public IQueryable<Product> GetProductsByDiscountQuarable(decimal Percentage, string Search)
        {
            var Quareble = _productRepository
            .GetTableNoTracking()
                .Where(x => x.Discount.Percentage == Percentage)
                .Include(x => x.Category)
                .Include(x => x.Discount)
                .Include(x => x.Reviews)
                .AsQueryable();
            if (!string.IsNullOrEmpty(Search))
            {
                Quareble = Quareble.Where(x => x.Name.Contains(Search) || x.Description.Contains(Search));
            }

            return Quareble;
        }

        public async Task<Product> GetLastAddedProductAsync()
        {
            return await _productRepository.GetLastAddedProductAsync();
        }
    }
}

