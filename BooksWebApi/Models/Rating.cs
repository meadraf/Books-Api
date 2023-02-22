namespace BooksWebApi.Models;

public class Rating
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public double Score { get; set; }
}