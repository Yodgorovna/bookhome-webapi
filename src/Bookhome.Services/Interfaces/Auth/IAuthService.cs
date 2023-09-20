using BookHome.Persistance.Dtos.Auth;

namespace Bookhome.Services.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result, int CashedHours)> RegisterAsync(RegisterDto dto);

    public Task<(bool Result, int CashedVerificationHours)> SendCodeForRegistrationAsync(string phone);

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code);
}
