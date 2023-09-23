using Bookhome.Persistance.Helpers;
using BookHome.Domain.Entities.Books;
using BookHome.Persistance.Validators.FileValidators;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Books
{
    public class BookImageUpdateValidator : AbstractValidator<BookImageUpdateDto>
    {
        public BookImageUpdateValidator()
        {
            RuleFor(x => x.ImagePath).SetValidator(new FileValidator());
        }
    }
}
