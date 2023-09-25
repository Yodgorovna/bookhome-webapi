using BookHome.Domain.Enums;

namespace BookHome.Persistance.Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirme { get; set; }

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public string District { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole IdentityRole { get; set; }

}
