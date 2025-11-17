using LibraryProductAPI.Models.Books;

namespace LibraryProductAPI.Repository.Books
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetAsync(int id);
        Task<IEnumerable<Book>> SearchAsync(string title, string author, string genre, int page, int pageSize);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}
