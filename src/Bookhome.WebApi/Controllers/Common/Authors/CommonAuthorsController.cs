using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Authors;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common.Authors
{
    [Route("api/common/authors")]
    [ApiController]
    public class CommonAuthorsController : CommonBaseController
    {
        private readonly IAuthorService _service;
        private readonly int maxPageSize = 30;

        public CommonAuthorsController(IAuthorService service)
        {
            this._service = service;
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetByIdAsync(long authorId)
            => Ok(await _service.GetByIdAsync(authorId));
    }
}
