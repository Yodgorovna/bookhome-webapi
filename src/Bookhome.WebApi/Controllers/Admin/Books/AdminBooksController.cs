using Bookhome.Services.Interfaces.Books;
using BookHome.Persistance.Dtos.Books;
using BookHome.Persistance.Validators.Dtos.Books;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Admin.Books
{
    [Route("api/admin/books")]
    [ApiController]
    public class AdminBooksController : AdminBaseController
    {
        private readonly IBookService _service;
        public AdminBooksController(IBookService bookService)
        {
            this._service = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] BookCreateDto dto)
        {
            var validator = new BookCreateValidator();
            var result = validator.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateAsync(long bookId, [FromForm] BookUpdateDto dto)
        {
            var validator = new BookUpdateValidator();
            var validationResult = validator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(bookId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteAsync(long bookId)
            => Ok(await _service.DeleteAsync(bookId));
    }
}
