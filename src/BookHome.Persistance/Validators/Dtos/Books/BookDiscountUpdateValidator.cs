using BookHome.Persistance.Dtos.Books;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Books;

public class BookDiscountUpdateValidator : AbstractValidator<BookDiscountUpdateDto>
{
    public BookDiscountUpdateValidator()
    {
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(3).WithMessage("Description field is required!");
    }
}
