using System.Linq;
using System.Threading.Tasks;
using BookShop.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DL.Repository
{
    public class ReviewRepository : IRepository<Review, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            _dbContext.Review.Remove(_dbContext.Review.Find(Id));
            var result = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            return result;
        }

        public IQueryable<Review> GetAll()
        {
            return _dbContext.Review;
        }

        public async Task<Review> GetByIdAsync(int Id) => await _dbContext.Review.FindAsync(Id);

        public async Task<bool> InsertAsync(Review entity)
        {
            await _dbContext.Review.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            return result;
        }

        public async Task<bool> UpdateAsync(Review entity)
        {
            var Review = await _dbContext.Review.FindAsync(entity.Id);
            if (Review == null)
                return false;
            Review.Title = entity.Title;
            Review.Content = entity.Content;
            Review.ReviewRating = entity.ReviewRating;
            var result = _dbContext.Entry(Review).State == EntityState.Modified ? true : false;
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}

