using BookHome.Persistance.Dtos.Auth;

namespace Bookhome.Services.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto dto);
    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phoneNumber);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phoneNumber, int code);
    public Task<(bool Result, string Token)> LoginAsync(LoginDto dto);
    public Task<(bool Result, int CachedMinutes)> ResetPasswordAsync(ResetPasswordDto dto);
    public Task<(bool Result, string Token)> VerifyResetPasswordAsync(string phoneNumber, int code);
    public Task<bool> CheckTokenAsync(AuthorizationDto token);
}
