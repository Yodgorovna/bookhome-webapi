using Bookhome.Persistance.Helpers;
using BookHome.Persistance.Dtos.Books;
using BookHome.Persistance.Validators.FileValidators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BookHome.Persistance.Validators.Dtos.Books;

public class BookCreateValidator : AbstractValidator<BookCreateDto>
{
    public BookCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
           .MinimumLength(3).WithMessage("First name must be more than 3 characters")
           .MaximumLength(50).WithMessage("First name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(3).WithMessage("Description must be more than 3 characters")
            .MaximumLength(50).WithMessage("Description must be less than 50 characters");

        RuleFor(dto => dto.CategoryId).NotNull().NotEmpty().WithMessage("CategoryId filed is required");
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("ImagePath filed is required");

        RuleFor(dto => dto.ImagePath).Must((dto, IFormFile) => IFormFile.Count <= 5)
            .WithMessage("There should be at least 5 images");
        RuleForEach(x => x.ImagePath).SetValidator(new FileValidator());
    }
}
