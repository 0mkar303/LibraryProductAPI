
using LibraryProductAPI.DTOs;
using LibraryProductAPI.Models.Books;
using LibraryProductAPI.Repository.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _repo.GetAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDto dto)
        {
            var model = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                Genre = dto.Genre,
                Quantity = dto.Quantity,
                PublishedDate = dto.PublishedDate,
                Publisher = dto.Publisher,
                Language = dto.Language,
                ShelfLocation = dto.ShelfLocation
            };

            var added = await _repo.AddAsync(model);
            return Ok(added);
        }

        // PUT: api/Books
        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto dto)
        {
            var book = await _repo.GetAsync(dto.Id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.Genre = dto.Genre;
            book.Quantity = dto.Quantity;
            book.PublishedDate = dto.PublishedDate;
            book.Publisher = dto.Publisher;
            book.Language = dto.Language;
            book.ShelfLocation = dto.ShelfLocation;

            await _repo.UpdateAsync(book);
            return Ok(book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool removed = await _repo.DeleteAsync(id);
            if (!removed) return NotFound();
            return Ok("Book deleted");
        }

        // SEARCH
        [HttpGet("search")]
        public async Task<IActionResult> Search(string title, string author, string genre, int page = 1, int pageSize = 5)
        {
            var result = await _repo.SearchAsync(title, author, genre, page, pageSize);
            return Ok(result);
        }
    }
}
