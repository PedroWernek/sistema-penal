using PenalSystem.Extensions;

namespace PenalSystem.Interfaces;

public interface IServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO> where TEntity : class, IEntity 
where TDTO : class where TCreateDTO : class where TUpdateDTO : class
{
    Task<List<TDTO>> GetEmployeesAsync(CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> CreateEmployeeAsync(TCreateDTO entity, CancellationToken cancellation = default);
    Task<TDTO> GetEmployeeByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> UpdateEmployeeAsync(Guid id, TUpdateDTO entity, CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> DeleteEmployeeAsync(Guid id, CancellationToken cancellation = default); 
}