using AutoMapper;
using BooksWebApi.DTO;
using BooksWebApi.Models;

namespace BooksWebApi.Mapping;

public class RatingProfile : Profile
{
    public RatingProfile()
    {
        CreateMap<RateBookDto, Rating>();
    }
}