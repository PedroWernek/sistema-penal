using AutoMapper;
using PenalSystem.DTOs;
using PenalSystem.Entities;

namespace PenalSystem.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDTO>();
        CreateMap<Book, BookCreateDTO>();
        
        CreateMap<BookDTO, BookCreateDTO>();
        CreateMap<BookDTO, Book>();

        CreateMap<BookCreateDTO, Book>();
    }
}