using BookShop.DL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.BL.Services
{
    public interface IReviewService
    {
        Task<Review> GetReviewByIdAsync(int reviewId);
        Task<IEnumerable<Review>> GetAllBookReviewsAsync(int bookId);
        Task<bool> AddReviewAsync(Review review);
        Task<bool> DeleteReviewByIdAsync(int reviewId);
        Task<bool> UpdateReviewAsync(Review review);
    }
}
