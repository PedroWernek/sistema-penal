using Microsoft.EntityFrameworkCore;
using PenalSystem.Interfaces;
using PenalSystem.Context;
using PenalSystem.Repositories.Base;
using PenalSystem.Entities.Abstractions;

namespace PenalSystem.Repositories;

public class PersonRepositoryBase<TEntity> : RepositoryBase<TEntity>, IPersonRepositoryBase<TEntity> where TEntity : Person
{
    public PersonRepositoryBase(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<TEntity> GetPersonByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Cpf == cpf);

        if (entity is null)
        {
            throw new KeyNotFoundException();
        }

        return entity;
    }
}