using BooksWebApi.DTO;
using FluentValidation;

namespace BooksWebApi.Validation;

public class SaveReviewDtoValidator : AbstractValidator<SaveReviewDto>
{
    public SaveReviewDtoValidator()
    {
        RuleFor(r => r.Message)
            .NotNull()
            .NotEmpty();
        RuleFor(r => r.Reviewer)
            .NotNull()
            .NotEmpty();
    }
}