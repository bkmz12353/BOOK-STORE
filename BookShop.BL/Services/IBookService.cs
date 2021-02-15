using BookShop.DL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.BL.Services
{
   public interface IBookService
    {
        Task<Book> GetBookByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetAllBookAsync();
        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteBookByIdAsync(int bookId);
        Task<bool> UpdateBookAsync(Book book);
    }
}
