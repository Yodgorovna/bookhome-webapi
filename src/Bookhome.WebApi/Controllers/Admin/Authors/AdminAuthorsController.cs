using Bookhome.Services.Interfaces.Authors;
using BookHome.Persistance.Dtos.Authors;
using BookHome.Persistance.Validators.Dtos.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Admin.Authors
{
    [Route("api/admin/authors")]
    [ApiController]
    public class AdminAuthorsController : AdminBaseController
    {
        private readonly IAuthorService _service;
        public AdminAuthorsController(IAuthorService authorService)
        {
            this._service = authorService;  
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] AuthorCreateDto dto)
        {
            var validator = new AuthorCreateValidator();
            var result = validator.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAsync(long authorId, [FromForm] AuthorUpdateDto dto)
        {
            var validator = new AuthorUpdateValidator();
            var validationResult = validator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(authorId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAsync(long authorId)
            => Ok(await _service.DeleteAsync(authorId));
    }
}
