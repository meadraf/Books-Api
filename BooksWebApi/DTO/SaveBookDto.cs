namespace BooksWebApi.DTO;

public class SaveBookDto
{
    public int? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Cover { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}