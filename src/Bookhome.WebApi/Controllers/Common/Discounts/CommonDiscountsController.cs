using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common.Discounts
{
    [Route("api/common/discounts")]
    [ApiController]
    public class CommonDiscountsController : CommonBaseController
    {
        private readonly IDiscountService _service;
        private readonly int maxPageSize = 30;

        public CommonDiscountsController(IDiscountService service)
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

