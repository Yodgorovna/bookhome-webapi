using Bookhome.Services.Interfaces.Categories;
using BookHome.Persistance.Dtos.Categories;
using BookHome.Persistance.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Admin.Categories;

[Route("api/admin/categories")]
[ApiController]
public class AdminCategoriesController : AdminBaseController
{
    private ICategoryService _service;
    public AdminCategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        var createValidator = new CategoryCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else
        {
            return BadRequest(result.Errors);
        }
    }


    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));


    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
        => Ok(await _service.UpdateAsync(categoryId, dto));

}
