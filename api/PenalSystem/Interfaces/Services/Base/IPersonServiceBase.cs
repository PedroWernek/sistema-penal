using PenalSystem.DTOs;
using PenalSystem.Entities.Abstractions;
using PenalSystem.Extensions;

namespace PenalSystem.Interfaces;

public interface IPersonServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO> where TEntity : Person
where TDTO : PersonDTO where TCreateDTO : PersonCreateDTO where TUpdateDTO : class
{
    Task<OperationResult<TEntity>> CreatePersonAsync(TCreateDTO userCreateDTO, CancellationToken cancellation = default);
    Task<TDTO> GetPersonByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<TDTO> GetPersonByCpfAsync(string cpf, CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> UpdatePersonAsync(Guid id, TUpdateDTO userUpdateDTO, CancellationToken cancellation = default);
    Task<OperationResult<TEntity>> DeletePersonAsync(Guid id, CancellationToken cancellation = default); 
    Task<List<TDTO>> GetPeopleAsync(CancellationToken cancellation = default);
}