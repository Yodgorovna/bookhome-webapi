using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common.Categories;

[Route("api/common/categories")]
[ApiController]
public class CommonCategoriesController : CommonBaseController
{
    private readonly ICategoryService _service;
    private readonly int maxPageSize = 30;

    public CommonCategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(await _service.GetByIdAsync(categoryId));

}
