using Microsoft.EntityFrameworkCore;
using PenalSystem.Interfaces;
using PenalSystem.Context;
using PenalSystem.Entities.Abstractions;

namespace PenalSystem.Repositories.Base;

public class ActivityRepositoryBase<TEntity> : RepositoryBase<TEntity>, IActivityRepositoryBase<TEntity> 
where TEntity : Activity
{
    public ActivityRepositoryBase(AppDbContext appContext) : base(appContext)
    {
    }

    async Task<List<TEntity>> IActivityRepositoryBase<TEntity>.GetActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation)
    {
        List<TEntity> entities = [];
        entities = await _dbSet.Where(x => x.PrisonerId == prisonerId).ToListAsync();

        return entities;
    }
}