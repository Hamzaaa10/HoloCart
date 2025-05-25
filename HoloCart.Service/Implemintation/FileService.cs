using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Service.Implemintation
{
    public class FileService : IFileService
    {
        #region Fileds
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseUrl;


        #endregion
        #region Constructors
        public FileService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            var request = _httpContextAccessor.HttpContext?.Request;
            _baseUrl = request != null ? $"{request.Scheme}://{request.Host}/" : "";

        }



        #endregion
        #region Handle Functions
        public async Task<string> UploadImage(string location, IFormFile file)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, location);
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString("N") + extension; // no dashes

            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    var fullFilePath = Path.Combine(uploadPath, fileName);

                    using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var relativePath = $"{location}/{fileName}".Replace("\\", "/");
                    return "/" + relativePath; // always start with "/"
                }
                catch (Exception)
                {
                    return "FailedToUploadImage";
                }
            }
            else
            {
                return "NoImage";
            }
        }


        public async Task<bool> DeleteImage(string imageUrl)
        {
            try
            {
                var filePath = imageUrl.Replace(_baseUrl, "").TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString());
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion
    }
}