using BooksWebApi.DTO;
using BooksWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApi.Controllers;

[Route("api/")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService, IConfiguration configuration)
    {
        _configuration = configuration;
        _bookService = bookService;
    }
    
    [HttpGet("books")]
    public async Task<ActionResult<List<GetBookDto>>> GetAllBooks(string? order)
    {
        var books = await _bookService.GetAllBooksAsync(order);

        return Ok(books);
    }
    
    [HttpGet("recommended")]
    public async Task<ActionResult<List<GetBookDto>>> GetTopBooks(string? genre)
    {
        var books = await _bookService.GetTopBooksAsync(genre);
        
        return Ok(books);
    }

    [HttpGet("books/{id}")]
    public async Task<ActionResult<GetBookDetailsDto?>> GetBookDetails(int id)
    {
        var book = await _bookService.GetBookDetailsAsync(id);

        if (book == null)
            return NotFound();
        
        return Ok(book);
    }
    
    [HttpDelete("books/{id}")]
    public async Task<IActionResult> DeleteBook(int id, [FromQuery] string secretKey)
    {
        var appSettingsSection = _configuration.GetSection("SecretKey");
        var appSettings = appSettingsSection.Get<AppSettings>();

        if (appSettings.SecretKey != secretKey)
        {
            return Unauthorized();
        }

        if (await _bookService.DeleteBookAsync(id))
            return Ok();
        
        return BadRequest();
    }
    
    [HttpPost("books/save")]
    public async Task<ActionResult<int>> SaveBook(SaveBookDto saveBookDto)
    {
        var id = await _bookService.SaveBookAsync(saveBookDto);

        if (id == 0)
            return BadRequest();
        
        return Ok(id);
    }
}