using System.Linq.Expressions;

namespace PenalSystem.Interfaces;

// CLASSE GENÉRICA: ela é inicializada com uma tal de TEntity, que é uma classe
// (assim como indicado pelo "where [...]") qualquer, mas que PRECISA herdar de 
// IEntity! as funções do repositório são genéricas pra CRUD
public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellation = default);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task AddAsync(TEntity entity, CancellationToken cancellation = default);
    Task Delete(TEntity entity, CancellationToken cancellation = default);
    Task Update(TEntity entity, CancellationToken cancellation = default);
}