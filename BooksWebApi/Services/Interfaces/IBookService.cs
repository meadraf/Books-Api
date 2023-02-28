using BooksWebApi.DTO;

namespace BooksWebApi.Services.Interfaces;

public interface IBookService
{
    public Task<List<GetBookDto>> GetAllBooksAsync(string order);
    public Task<List<GetBookDto>> GetTopBooksAsync(string genre);
    public Task<GetBookDetailsDto?> GetBookDetailsAsync(int id);
    public Task<bool> DeleteBookAsync(int id);
    public Task<int> SaveBookAsync(SaveBookDto saveBookDto);
}