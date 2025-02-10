using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(BookRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Books book)
        {
            if (book == null)
                return BadRequest();

            BookRepository.Add(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Books book)
        {
            if (book == null || book.Id != id)
                return BadRequest();

            var existingBook = BookRepository.GetById(id);
            if (existingBook == null)
                return NotFound();

            BookRepository.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
                return NotFound();

            BookRepository.Delete(id);
            return NoContent();
        }
    }
}
