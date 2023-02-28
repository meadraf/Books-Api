using BooksWebApi.DTO;
using FluentValidation;

namespace BooksWebApi.Validation;

public class SaveBookDtoValidator : AbstractValidator<SaveBookDto>
{
    public SaveBookDtoValidator()
    {
        RuleFor(b => b.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(b => b.Content)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);;
        RuleFor(b => b.Author)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);;
        RuleFor(b => b.Genre)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);;
    }
}