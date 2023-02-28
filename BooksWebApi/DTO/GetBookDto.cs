namespace BooksWebApi.DTO;

public class GetBookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public int ReviewsNumber { get; set; } 
}