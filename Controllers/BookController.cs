using BookAPI.Model;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBooks(int Id)
        {
            return await _bookRepository.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = newBook.Id}, newBook);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var bookToDelete = await _bookRepository.Get(Id);

            if (bookToDelete == null)
                return NotFound();
            await _bookRepository.Delete(bookToDelete.Id);
                return NoContent();
        }

        [HttpPut]

        public async Task<ActionResult> PutBooks(int Id,[FromBody] Book book)
        {
            if (Id != book.Id)
                return BadRequest();    

                await _bookRepository.Update(book);
                
                return NoContent();
        }
    }
}
