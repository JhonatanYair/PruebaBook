using ApiBookTest.Models;
using ApiBookTest.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService bookService;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooks(int? id = 0)
        {
            return Ok(await bookService.GetBooks(id));
        }

        [HttpGet("Author/{idAuthor}")]
        public async Task<IActionResult> GetBooksAuthor(int idAuthor)
        {
            return Ok(await bookService.GetBooksAuthor(idAuthor));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] books book)
        {
            return Ok(await bookService.CreateBook(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] books book)
        {
            var responseService = await bookService.UpdateBook(id, book);
            if (responseService.CodeHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(responseService);
            }
            else
            {
                return BadRequest(responseService);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var responseService = await bookService.RemoveBook(id);
            if (responseService.CodeHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(responseService);
            }
            else
            {
                return BadRequest(responseService);
            }
        }
    }
}
