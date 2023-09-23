using BookHome.Domain.Entities;
using BookHome.Domain.Enums;

namespace Bookhome.DataAcces.ViewModels.Users;

public class UserViewModel : Auditable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public string District { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole IdentityRole { get; set; }

}
