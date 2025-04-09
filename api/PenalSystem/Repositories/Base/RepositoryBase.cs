using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PenalSystem.Interfaces;
using PenalSystem.Context;

namespace PenalSystem.Repositories.Base;

// de novo, classe genérica (+ explicações na interface)
public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    public readonly DbSet<TEntity> _dbSet; // pega a tabela certa
    public readonly AppDbContext _ctx; // contexto

    public RepositoryBase(AppDbContext appContext)
    {
        _dbSet = appContext.Set<TEntity>();
        _ctx = appContext;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellation = default)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task Delete(TEntity entity, CancellationToken cancellation)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellation = default)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
        {
            query = query
                .Where(filter)
                .AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
        {
            throw new KeyNotFoundException();
        }

        return entity;
    }

    public Task Update(TEntity entity, CancellationToken cancellation)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }
}