using BooksWebApi.Models;

namespace BooksWebApi.DTO;

public class GetBookDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Cover { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public List<SaveReviewDto> Reviews { get; set; } = new();
}