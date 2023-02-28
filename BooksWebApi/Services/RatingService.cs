using AutoMapper;
using BooksWebApi.DataBase;
using BooksWebApi.DTO;
using BooksWebApi.Models;
using BooksWebApi.Services.Interfaces;

namespace BooksWebApi.Services;

public class RatingService :IRatingService
{
    private readonly BookDbContext _dbContext;
    private readonly IMapper _mapper;

    public RatingService(BookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task RateBook(int id, RateBookDto rateBookDto)
    {
        var rating = _mapper.Map<Rating>(rateBookDto);
        rating.BookId = id;
        _dbContext.Ratings.Add(rating);
        await _dbContext.SaveChangesAsync();
    }
}