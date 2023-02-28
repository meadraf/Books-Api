using BooksWebApi.DTO;

namespace BooksWebApi.Services.Interfaces;

public interface IRatingService
{
    public Task RateBook(int id, RateBookDto rateBookDto);
}