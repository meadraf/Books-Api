using BooksWebApi.DTO;
using BooksWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApi.Controllers;

[Route("api/")]
[ApiController]
public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }
    [HttpPut("books/{id}/rate")]
    public async Task<IActionResult> RateBook(int id, RateBookDto rateBookDto)
    {
        await _ratingService.RateBook(id, rateBookDto);
        return Ok();
    }
}