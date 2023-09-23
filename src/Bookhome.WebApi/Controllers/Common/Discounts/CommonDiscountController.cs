using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common.Discounts
{
    [Route("api/common/discount")]
    [ApiController]
    public class CommonDiscountController : BaseController
    {
        private readonly IDiscountService _service;
        private readonly int maxPageSize = 30;

        public CommonDiscountController(IDiscountService service)
        {
            this._service = service;
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpGet("{discountId}")]
        public async Task<IActionResult> GetByIdAsync(long discountId)
            => Ok(await _service.GetByIdAsync(discountId));

    }
}

