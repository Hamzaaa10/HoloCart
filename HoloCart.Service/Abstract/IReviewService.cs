using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IReviewService
    {
        public Task<string> AddReviewAsync(Review review);
        public Task<string> UpdateReviewAsync(Review Review);
        public Task<Review> GetReviewByIdAsync(int ReviewId);
        public Task<string> DeleteReviewAsync(int ReviewId);
        public Task<List<Review>> GetAllReviewsWithProductAcync(int ProductId);

    }
}
