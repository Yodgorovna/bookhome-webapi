using BookHome.Persistance.Dtos.Authors;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Authors;

public class AuthorUpdateValidator : AbstractValidator<AuthorUpdateDto>
{
    public AuthorUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("First name field is required!")
           .MinimumLength(3).WithMessage("First name must be more than 3 characters")
           .MaximumLength(50).WithMessage("First name must be less than 50 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Last name field is required!")
            .MinimumLength(3).WithMessage("Last name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Last name must be less than 50 characters");

        RuleFor(dto => dto.Country).NotNull().NotEmpty().WithMessage("Country field is required!")
            .MinimumLength(3).WithMessage("Country must be more than 1 characters")
            .MaximumLength(50).WithMessage("Country must be less than 30 characters");
    }
}
