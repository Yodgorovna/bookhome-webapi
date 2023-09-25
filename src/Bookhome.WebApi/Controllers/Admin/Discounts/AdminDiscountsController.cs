using Bookhome.Services.Interfaces.Discounts;
using BookHome.Persistance.Dtos.Discounts;
using BookHome.Persistance.Validators.Dtos.Discounts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Admin.Discounts;

[Route("api/admin/discounts")]
[ApiController]
public class AdminDiscountsController : AdminBaseController
{
    private IDiscountService _service;
    public AdminDiscountsController(IDiscountService service)
    {
        this._service = service;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] DiscountCreateDto dto)
    {
        var createValidator = new DiscountCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else
        {
            return BadRequest(result.Errors);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long discountId)
        => Ok(await _service.DeleteAsync(discountId));


    [HttpPut]
    public async Task<IActionResult> UpdateAsync(long discountId, [FromForm] DiscountUpdateDto dto)
        => Ok(await _service.UpdateAsync(discountId, dto));

}
