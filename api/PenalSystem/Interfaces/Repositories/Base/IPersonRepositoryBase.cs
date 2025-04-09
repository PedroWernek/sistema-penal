using PenalSystem.Entities.Abstractions;

namespace PenalSystem.Interfaces;

public interface IPersonRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Person
{
    Task <TEntity> GetPersonByCpfAsync (string cpf, CancellationToken cancellation = default);
}