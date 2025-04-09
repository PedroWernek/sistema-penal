using AutoMapper;
using PenalSystem.DTOs;
using PenalSystem.Entities;
using PenalSystem.Interfaces;
using PenalSystem.Services.Base;

namespace PenalSystem.Services;

public class BookService : ActivityService<Book, BookDTO, BookCreateDTO, IBookRepository>, IBookService
{
    public BookService(IUnitOfWork uow, IMapper mapper, IBookRepository repository) : base(uow, mapper, repository)
    {
    }
}