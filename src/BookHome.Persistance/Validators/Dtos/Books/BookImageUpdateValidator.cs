using Bookhome.Persistance.Helpers;
using BookHome.Domain.Entities.Books;
using FluentValidation;

namespace BookHome.Persistance.Validators.Dtos.Books
{
    public class BookImageUpdateValidator : AbstractValidator<BookImageUpdateDto>
    {
        public BookImageUpdateValidator()
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");
            RuleFor(dto => dto.ImagePath.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        }
    }
}
