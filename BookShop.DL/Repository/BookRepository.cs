using System.Linq;
using System.Threading.Tasks;
using BookShop.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DL.Repository
{
    public class BookRepository : IRepository<Book, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var BookReviews = _dbContext.Review.Where(t => t.ReviewBookID == Id).ToList();

            foreach (var review in BookReviews)
            {
                _dbContext.Review.Remove(review);
            }

            _dbContext.Book.Remove(_dbContext.Book.Find(Id));
            var result = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            return result;
        }

        public IQueryable<Book> GetAll()
        {
            return _dbContext.Book;
        }

        public async Task<Book> GetByIdAsync(int Id) => await _dbContext.Book.FindAsync(Id);

        public async Task<bool> InsertAsync(Book entity)
        {
            await _dbContext.Book.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            return result;
        }

        public async Task<bool> UpdateAsync(Book entity)
        {
            var Book = await _dbContext.Book.FindAsync(entity.Id);
            if (Book == null)
                return false;
            Book.Name = entity.Name;
            Book.Author = entity.Author;
            Book.Count = entity.Count;
            Book.Price = entity.Price;
            Book.Description = entity.Description;
            var result = _dbContext.Entry(Book).State == EntityState.Modified ? true : false;
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}

