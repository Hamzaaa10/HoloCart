using Microsoft.AspNetCore.Http;

namespace HoloCart.Service.Abstract
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);

    }
}
