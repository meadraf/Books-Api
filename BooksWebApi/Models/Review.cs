namespace BooksWebApi.Models;

public class Review
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public int BookId { get; set; }
    public string Reviewer { get; set; } = string.Empty;
}