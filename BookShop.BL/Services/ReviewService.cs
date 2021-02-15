using BookShop.DL.Models;
using BookShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review, int> _reviewRepository;
        public ReviewService(IRepository<Review, int> reviewRepository)
        {
            if (reviewRepository != null)
            {
                _reviewRepository = reviewRepository;
            }
        }
        public async Task<bool> AddReviewAsync(Review review)
        {
            if(review.Title.Length>1 && review.Content.Length>1)
            {
                return await _reviewRepository.InsertAsync(review);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteReviewByIdAsync(int reviewId)
        {
            return await _reviewRepository.DeleteAsync(reviewId);
        }

        public async Task<IEnumerable<Review>> GetAllBookReviewsAsync(int bookId)
        {
            return await Task.FromResult(_reviewRepository.GetAll().Where(x => x.ReviewBookID == bookId));
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _reviewRepository.GetByIdAsync(reviewId);
        }

        public async Task<bool> UpdateReviewAsync(Review review)
        {
            return await _reviewRepository.UpdateAsync(review);
        }
    }
}
