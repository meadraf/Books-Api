using AutoMapper;
using BooksWebApi.DTO;
using BooksWebApi.Models;

namespace BooksWebApi.Mapping;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<SaveBookDto, Book>();
        CreateMap<Book, GetBookDto>()
            .ForMember(dest => dest.ReviewsNumber,
                option => option.MapFrom(src => src.Reviews!.Count))
            .ForMember(dest => dest.Rating,
                option => option.MapFrom(src => src.Ratings!.Any() ? src.Ratings!.Average(r => r.Score) : 0));
        
        CreateMap<Book, GetBookDetailsDto>()
            .ForMember(dest => dest.Rating,
                option => option.MapFrom(src => src.Ratings!.Any() ? src.Ratings!.Average(r => r.Score) : 0));
    }
}