using Microsoft.EntityFrameworkCore;
using LibraryProductAPI.Models.Books;
namespace LibraryProductAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
       
        

    }
}

