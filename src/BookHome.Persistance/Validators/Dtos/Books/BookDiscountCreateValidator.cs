using BookHome.Persistance.Dtos.Books;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Books;

public class BookDiscountCreateValidator : AbstractValidator<BookDiscountCreateDto>
{
    public BookDiscountCreateValidator()
    {
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(3).WithMessage("Description field is required!");
    }
}
