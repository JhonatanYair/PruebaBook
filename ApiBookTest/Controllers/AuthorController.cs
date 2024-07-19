using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiBookTest.Repositories;
using ApiBookTest.Models;
using ApiBookTest.Common;
using ApiBookTest.Service;


namespace ApiBookTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService authorService;


        public AuthorController(IAuthorService _authorService) 
        {
            authorService = _authorService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetAuthors(int? id = 0)
        {
            return Ok(await authorService.GetAuthors(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] authors author)
        {
            return Ok(await authorService.CreateAuthor(author));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] authors author)
        {
            var responseService = await authorService.UpdateAuthor(id, author);
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
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var responseService = await authorService.RemoveAuthor(id);
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
