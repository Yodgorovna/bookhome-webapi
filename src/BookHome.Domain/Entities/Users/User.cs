using BookHome.Domain.Enums;

namespace BookHome.Domain.Entities.Users;

public class User : Auditable
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

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole IdentityRole { get; set; }

}
