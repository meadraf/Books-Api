using BooksWebApi.DTO;
using FluentValidation;

namespace BooksWebApi.Validation;

public class RateBookDtoValidator : AbstractValidator<RateBookDto>
{
    public RateBookDtoValidator()
    {
        RuleFor(r => r.Score)
            .InclusiveBetween(1, 5);
    }
}