using BookHome.Persistance.Dtos.Books;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Books;

public class BookUpdateValidator : AbstractValidator<BookUpdateDto>
{
    public BookUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
           .MinimumLength(3).WithMessage("First name must be more than 3 characters")
           .MaximumLength(50).WithMessage("First name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(3).WithMessage("Description must be more than 3 characters")
            .MaximumLength(50).WithMessage("Description must be less than 50 characters");

        RuleFor(dto => dto.CategoryId).NotNull().NotEmpty().WithMessage("CategoryId filed is required");
    }
}
