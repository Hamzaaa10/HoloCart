using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<string> AddReviewAsync(Review review)
        {
            var existingReview = await _reviewRepository.GetTableNoTracking().Where(r =>
          r.ApplicationUserId == review.ApplicationUserId && r.ProductId == review.ProductId).FirstOrDefaultAsync();

            if (existingReview != null)
            {
                return "UserAlreadyReviewed";
            }
            try
            {
                await _reviewRepository.AddAsync(review);
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddReviewAsync: {ex.Message}");
                return "FailedInAdd";
            }
        }

        public async Task<string> DeleteReviewAsync(int ReviewId)
        {
            var Review = await _reviewRepository.GetByIdAsync(ReviewId);
            if (Review == null) return "NotFound";

            try
            {
                await _reviewRepository.DeleteAsync(Review);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }
        }

        public async Task<List<Review>> GetAllReviewsWithProductAcync(int ProductId)
        {
            return await _reviewRepository.GetTableNoTracking()
           .Where(r => r.ProductId == ProductId)
           .Include(r => r.User)
           .ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int ReviewId)
        {
            return await _reviewRepository.GetByIdAsync(ReviewId);
        }

        public async Task<string> UpdateReviewAsync(Review Review)
        {

            try
            {
                await _reviewRepository.UpdateAsync(Review);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }
    }
}
