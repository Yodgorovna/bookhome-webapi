using BookHome.Domain.Entities.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Category category)
    {
        return Ok();
    }
}
