using BookHome.Persistance.Dtos.Users;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
	public UserUpdateValidator()
	{

	}
}
