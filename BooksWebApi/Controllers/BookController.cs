using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApi.Controllers;

[Route("api/")]
[ApiController]
public class BookController : ControllerBase
{
    // GET: api/Book
    [HttpGet("books")]
    public async Task<ActionResult<IEnumerable<string>>> GetAllBooks()
    {
        return new string[] {"value1", "value2"};
    }

    // GET: api/Book/5
    [HttpGet("recommended")]
    public async Task<ActionResult<string>> GetTopBooks(int id)
    {
        return "value";
    }

    [HttpGet("books/{id}")]
    public async Task<ActionResult<string>> GetBookDetails(int id)
    {
        return "value";
    }
    
    [HttpDelete("books/{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
        return "value";
    }
    
    // POST: api/Book
    [HttpPost("books/save")]
    public async Task<ActionResult<string>> SaveBook([FromBody] string value)
    {
        return "value";
    }
    
    [HttpPut("books/{id}/review")]
    public async Task<ActionResult<string>> SaveReview([FromBody] string value, int id)
    {
        return "value";
    }

    // PUT: api/Book/5
    [HttpPut("books/{id}/rate")]
    public async Task<ActionResult<string>> Put(int id, [FromBody] string value)
    {
        return "value";
    }

    
}