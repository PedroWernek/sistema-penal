using PenalSystem.Extensions;

namespace PenalSystem.Interfaces.Base;

public interface IUserServiceService<TEntity, TDTO, TCreateDTO, TUpdateDTO> where TEntity : class, IEntity
where TDTO : class where TCreateDTO : class where TUpdateDTO : class
{
    Task<OperationResult<TEntity>> CreateUserAsync(TCreateDTO entity, CancellationToken cancellation = default);
    Task<TDTO> GetUserByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<TDTO> GetUserByCpfAsync(string cpf, CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> UpdateUserAsync(Guid id, TUpdateDTO updatedPrisoner, CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> DeleteUserAsync(Guid id, CancellationToken cancellation = default); 
    Task<List<TDTO>> GetUsersAsync(CancellationToken cancellation = default);
}