using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common.Users
{
    [Route("api/common/user")]
    [ApiController]
    public class CommonUsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly int maxPageSize = 30;

        public CommonUsersController(IUserService service)
        {
            this._service = service;
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


        
    }
}
