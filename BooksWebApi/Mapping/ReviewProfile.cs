using AutoMapper;
using BooksWebApi.DTO;
using BooksWebApi.Models;

namespace BooksWebApi.Mapping;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, SaveReviewDto>().ReverseMap();
    }
}