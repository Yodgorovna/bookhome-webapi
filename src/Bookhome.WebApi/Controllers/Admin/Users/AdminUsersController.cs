using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Admin.Users
{
    [Route("api/admin/users")]
    [ApiController]
    public class AdminUsersController : AdminBaseController
    {
        private readonly IUserService _userService;
        private readonly int maxPage = 20;

        public AdminUsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(int userId)
            => Ok(await _userService.GetByIdAsync(userId));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _userService.CountAsync());

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(long userId)
            => Ok(await _userService.DeleteAsync(userId));

        //[HttpGet("search")]

        //public async Task<IActionResult> SearchAsync([FromQuery] string search)
        //{
        //    var res = (await _userService.SearchAsync(search));

        //    return Ok(new { res.IteamCount, res.Item2 });
        //}

        //[HttpGet("{userId}")]
        //public async Task<IActionResult> GetByIdAsync(long userId)
        //    => Ok(await _userService.GetByIdAsync(userId));
    }
}
