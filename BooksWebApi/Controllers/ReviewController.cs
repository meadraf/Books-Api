using BooksWebApi.DTO;
using BooksWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApi.Controllers;

[Route("api/")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [HttpPut("books/{id}/review")]
    public async Task<ActionResult<string>> SaveReview(int id, SaveReviewDto saveReviewDto)
    {
        var reviewId = await _reviewService.SaveReview(id, saveReviewDto);
        return Ok(reviewId);
    }
}