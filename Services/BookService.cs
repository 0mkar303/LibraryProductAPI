using LibraryProductAPI.Data;
using LibraryProductAPI.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryProductAPI.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return book;
        }
    }

}
