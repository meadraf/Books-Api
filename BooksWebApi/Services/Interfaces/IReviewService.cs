using BooksWebApi.DTO;

namespace BooksWebApi.Services.Interfaces;

public interface IReviewService
{
    public Task<int> SaveReview(int bookId, SaveReviewDto reviewDto);
}