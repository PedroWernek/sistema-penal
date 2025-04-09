using PenalSystem.Extensions;

namespace PenalSystem.Interfaces.Base;

public interface IActivityServiceBase<TEntity, TDTO, TCreateDTO> where TEntity : class, IEntity 
where TDTO : class where TCreateDTO : class
{
    Task<OperationResult<TEntity>> CreateActivityAsync(TCreateDTO entity, CancellationToken cancellation = default);
    Task<List<TDTO>> GetActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default);
    Task<List<TDTO>> GetActivitiesAsync(CancellationToken cancellation = default);
}