namespace PenalSystem.Interfaces;

public interface IActivityRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> GetActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default);
}