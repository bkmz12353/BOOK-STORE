using BookShop.DL.Models;
using BookShop.DL.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book, int> _bookRepository;
        public BookService(IRepository<Book, int> bookRepository)
        {
            if (bookRepository != null)
            {
                _bookRepository = bookRepository;
            }
        }
        public async Task<bool> AddBookAsync(Book book)
        {
            if(book.Name.Length>1 && book.Author.Length>3)
            {
                return await _bookRepository.InsertAsync(book);
            }
            return await Task.FromResult(false);   
        }

        public async Task<bool> DeleteBookByIdAsync(int bookId)
        {
            return await _bookRepository.DeleteAsync(bookId);
        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await Task.FromResult(_bookRepository.GetAll());
        }

        public async Task<Book> GetBookByIdAsync(int bookId) 
        {
           return await _bookRepository.GetByIdAsync(bookId);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }
    }
}
