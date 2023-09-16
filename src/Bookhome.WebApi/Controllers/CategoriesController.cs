using Bookhome.DataAcces.Interfaces.Categories;
using Bookhome.DataAcces.Repositories.Categories;
using Bookhome.Services.Interfaces.Categories;
using BookHome.Persistance.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _service.CreateAsync(dto)); 
}
