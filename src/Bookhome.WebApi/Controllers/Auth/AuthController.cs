using Bookhome.Services.Interfaces.Auth;
using Bookhome.Services.Interfaces.Users;
using Bookhome.WebApi.Controllers.Common;
using BookHome.Persistance.Dtos.Auth;
using BookHome.Persistance.Validators;
using BookHome.Persistance.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController : CommonBaseController
{
    private readonly IAuthService _authService;
    private readonly IUserService _user;

    public AuthController(IUserService user,
        IAuthService authService,
        IConfiguration configuration)
    {
        _authService = authService;
        _user = user;
    }

    //[HttpGet("check/user/role")]
    //public async Task<IActionResult> GetUserRole()
    //    => Ok(await _userRole.GetRole());

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto dto)
    {
        RegisterValidator validations = new RegisterValidator();
        var resltvalid = validations.Validate(dto);
        if (resltvalid.IsValid)
        {
            var result = await _authService.RegisterAsync(dto);

            return Ok(new { result.Result, result.CachedMinutes });
        }
        else
            return BadRequest(resltvalid.Errors);

    }

    [HttpPost("register/send-code")]
    public async Task<IActionResult> SendCodeAsync(string phone)
    {
        var valid = PhoneNumberValidator.IsValid(phone);
        if (valid)
        {
            var result = await _authService.SendCodeForRegisterAsync(phone);

            return Ok(new { result.Result, result.CachedVerificationMinutes });
        }
        else
            return BadRequest("Phone number invalid");

    }

    [HttpPost("register/verify")]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto dto)
    {
        var res = PhoneNumberValidator.IsValid(dto.PhoneNumber);
        if (res == false) return BadRequest("Phone number is invalid!");
        var srResult = await _authService.VerifyRegisterAsync(dto.PhoneNumber, dto.Code);
        return Ok(new { srResult.Result, srResult.Token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
    {
        var validator = new LoginValidator();
        var valResult = validator.Validate(dto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _authService.LoginAsync(dto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

    [HttpPost("password/reset")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto forgot)
    {
        var res = PhoneNumberValidator.IsValid(forgot.PhoneNumber);
        var password = PasswordValidator.IsStrongPassword(forgot.NewPassword);
        if (res == false)
            return BadRequest("Phone number is invalid!");
        else if (password.IsValid == false)
            return BadRequest(password.Message);

        var serviceResult = await _authService.ResetPasswordAsync(forgot);

        return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
    }

    [HttpPost("password/verify")]
    public async Task<IActionResult> PasswordVerifyAsync([FromBody] VerifyRegisterDto verfyUser)
    {
        var res = PhoneNumberValidator.IsValid(verfyUser.PhoneNumber);
        if (res == false) return BadRequest("Phone number is invalid!");
        var srResult = await _authService.VerifyResetPasswordAsync(verfyUser.PhoneNumber, verfyUser.Code);

        return Ok(new { srResult.Result, srResult.Token });
    }

    [HttpPost("token/verify")]
    public async Task<IActionResult> CheckToken([FromBody] AuthorizationDto token)
    {
        var requedt = await _authService.CheckTokenAsync(token);

        return Ok(requedt);
    }
}
