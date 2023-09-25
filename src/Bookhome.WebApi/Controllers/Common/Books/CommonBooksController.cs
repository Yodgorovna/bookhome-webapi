using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Books;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common.Books
{
    [Route("api/common/books")]
    [ApiController]
    public class CommonBooksController : CommonBaseController
    {
        private readonly IBookService _service;
        private readonly int maxPageSize = 30;

        public CommonBooksController(IBookService service)
        {
            this._service = service;
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetByIdAsync(long bookId)
            => Ok(await _service.GetByIdAsync(bookId));
    }
}
