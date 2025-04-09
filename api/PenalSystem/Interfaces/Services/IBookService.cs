using PenalSystem.DTOs;
using PenalSystem.Entities;
using PenalSystem.Interfaces.Base;

namespace PenalSystem.Interfaces;

public interface IBookService : IActivityServiceBase<Book, BookDTO, BookCreateDTO>
{
}