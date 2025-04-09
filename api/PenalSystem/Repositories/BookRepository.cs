using PenalSystem.Entities;
using PenalSystem.Interfaces;
using PenalSystem.Context;
using PenalSystem.Repositories.Base;

namespace PenalSystem.Repositories;

public class BookRepository : ActivityRepositoryBase<Book>, IBookRepository
{
    public BookRepository(AppDbContext appContext) : base(appContext)
    {
    }
}