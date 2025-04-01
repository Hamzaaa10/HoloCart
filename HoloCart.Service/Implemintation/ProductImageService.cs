using HoloCart.Data.Entities;
using HoloCart.Infrastructure;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Service.Implemintation
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageService(IProductImageRepository productImageRepository,
            IHttpContextAccessor httpContextAccessor,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment)
        {
            _productImageRepository = productImageRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> AddProductAsync(ProductImage productImage, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("ProductImages", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            productImage.ImageUrl = baseUrl + imageUrl;
            try
            {
                await _productImageRepository.AddAsync(productImage);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }

        }

        public async Task<string> DeleteProductAsync(int id)
        {
            var productImage = await _productImageRepository.GetByIdAsync(id);
            if (productImage == null)
                return "ProductImageNotFound";

            // Step 2: Delete the image from storage
            var imageUrl = productImage.ImageUrl;
            var deleteResult = await _fileService.DeleteImage(imageUrl);
            if (!deleteResult)
                return "FailedToDeleteImage";

            // Step 3: Delete the record from the database
            try
            {
                await _productImageRepository.DeleteAsync(productImage);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedToDelete";
            }
        }

        public async Task<ProductImage> GetProductImageById(int id)
        {
            return await _productImageRepository.GetByIdAsync(id);
        }

        public async Task<string> UpdateProductAsync(int id, ProductImage productImage, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            if (file != null && file.Length > 0)
            {
                // **Delete old image if exists**
                if (!string.IsNullOrEmpty(productImage.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        productImage.ImageUrl.Replace(baseUrl, "").TrimStart('/'));

                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                var imageUrl = await _fileService.UploadImage("ProductImages", file);
                switch (imageUrl)
                {
                    case "NoImage": return "NoImage";
                    case "FailedToUploadImage": return "FailedToUploadImage";
                }
                productImage.ImageUrl = baseUrl + imageUrl;
            }
            else
            {
                productImage.ImageUrl = productImage.ImageUrl; // Retain old image if no new file
            }
            try
            {
                await _productImageRepository.UpdateAsync(productImage);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }
    }
}
