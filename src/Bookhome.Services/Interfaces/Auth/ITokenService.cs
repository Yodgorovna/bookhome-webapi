using BookHome.Domain.Entities.Users;

namespace Bookhome.Services.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
