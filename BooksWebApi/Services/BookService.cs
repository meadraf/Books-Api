using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksWebApi.DataBase;
using BooksWebApi.DTO;
using BooksWebApi.Models;
using BooksWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Services;

public class BookService : IBookService
{
    private readonly BookDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookService(BookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<GetBookDto>> GetAllBooksAsync(string order)
    {
        var query = _dbContext.Books.ProjectTo<GetBookDto>(_mapper.ConfigurationProvider);
        switch (order)
        {
            case "title":
                query = query.OrderBy(b => b.Title);
                break;
            case "author":
                query = query.OrderBy(b => b.Author);
                break;
        }

        return await query.ToListAsync();
    }

    public async Task<List<GetBookDto>> GetTopBooksAsync(string genre)
    {
        var query = _dbContext.Books.AsQueryable();

        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(b => b.Genre == genre);
        }

        return await query.ProjectTo<GetBookDto>(_mapper.ConfigurationProvider)
            .Where(b => b.ReviewsNumber > 10)
            .Take(10)
            .ToListAsync();
    }

    public async Task<GetBookDetailsDto?> GetBookDetailsAsync(int id)
    {
        return await _dbContext.Books.Include(b => b.Reviews)
            .ProjectTo<GetBookDetailsDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var bookToRemove = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (bookToRemove == null)
            return false;

        _dbContext.Books.Remove(bookToRemove);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<int> SaveBookAsync(SaveBookDto saveBookDto)
    {
        if (saveBookDto.Id is null or 0)
            return await AddNewBook(saveBookDto);
        
        if (_dbContext.Books.Any(b => b.Id == saveBookDto.Id))
            return await UpdateBook(saveBookDto);
        
        return 0;
    }

    private async Task<int> UpdateBook(SaveBookDto saveBookDto)
    {
        var formerBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == saveBookDto.Id);
        var updatedBook = _mapper.Map(saveBookDto, formerBook);
        _dbContext.Update(updatedBook);
        await _dbContext.SaveChangesAsync();
        
        return updatedBook.Id;
    }

    private async Task<int> AddNewBook(SaveBookDto saveBookDto)
    {
        var book = _mapper.Map<Book>(saveBookDto);
        var bookId = (await _dbContext.Books.AddAsync(book)).Entity.Id;
        await _dbContext.SaveChangesAsync();
        
        return bookId;
    }
}