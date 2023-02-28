using AutoMapper;
using BooksWebApi.DataBase;
using BooksWebApi.DTO;
using BooksWebApi.Models;
using BooksWebApi.Services.Interfaces;

namespace BooksWebApi.Services;

public class ReviewService : IReviewService
{
    private readonly BookDbContext _dbContext;
    private readonly IMapper _mapper;

    public ReviewService(BookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<int> SaveReview(int bookId, SaveReviewDto reviewDto)
    {
        var review = _mapper.Map<Review>(reviewDto);
        review.BookId = bookId;
        var newReviewId = (await _dbContext.Reviews.AddAsync(review)).Entity.Id;
        await _dbContext.SaveChangesAsync();
        return newReviewId;
    }
}