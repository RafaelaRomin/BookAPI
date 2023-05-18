using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookAPI.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
            {
            Database.EnsureCreated();
            }
            
        public DbSet<Book> Books { get; set;}
    }
}
