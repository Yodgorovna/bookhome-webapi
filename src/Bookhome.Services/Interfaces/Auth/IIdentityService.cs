using BookHome.Domain.Enums;

namespace Bookhome.Services.Interfaces.Auth;

public interface IIdentityService
{
    public long Id { get; }
    public IdentityRole? IdentityRole { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
}
