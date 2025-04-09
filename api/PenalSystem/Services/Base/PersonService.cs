using AutoMapper;
using PenalSystem.DTOs;
using PenalSystem.Entities.Abstractions;
using PenalSystem.Enums;
using PenalSystem.Extensions;
using PenalSystem.Interfaces;

namespace PenalSystem.Services;

public class PersonService<TEntity, TDTO, TCreateDTO, TUpdateDTO, TRepository> : IPersonServiceBase<TEntity, TDTO, TCreateDTO, TUpdateDTO>
where TEntity : Person where TDTO : PersonDTO where TCreateDTO : PersonCreateDTO where TUpdateDTO : class where TRepository : IPersonRepositoryBase<TEntity>
{
    private readonly TRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public PersonService(TRepository repository, IUnitOfWork uow, IMapper mapper)
    {
        _repository = repository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<OperationResult<TEntity>> CreatePersonAsync(TCreateDTO entityCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<TEntity>();

        if (entityCreateDTO is null)
        {
            return new OperationResult<TEntity>(
                new ResultMessage("Invalid person creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var entity = _mapper.Map<TEntity>(entityCreateDTO);

            await _repository.AddAsync(entity, cancellation);
            await _uow.CommitTransactionAsync();

            result = new OperationResult<TEntity> { Value = entity };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<TEntity>(
                new ResultMessage($"Failed to create user: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<OperationResult<TEntity>> DeletePersonAsync(Guid id, CancellationToken cancellation = default)
    {
        var result = new OperationResult<TEntity>();

        var entityDTO = GetPersonByIdAsync(id);
        var entity = _mapper.Map<TEntity>(entityDTO);

        await _uow.BeginTransactionAsync();
        try
        {
            await _repository.Delete(entity, cancellation);
            await _uow.CommitTransactionAsync();

            result = new OperationResult<TEntity> { Value = entity };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<TEntity>(
                new ResultMessage($"Failed to delete user: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<TDTO> GetPersonByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("Invalid CPF.");
        
        var entity = await _repository.GetPersonByCpfAsync(cpf, cancellation);
        var entityDTO = _mapper.Map<TDTO>(entity);
        return entityDTO;
    }

    public async Task<TDTO> GetPersonByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid ID.");
        
        var entity = await _repository.GetByIdAsync(id, cancellation);
        var entityDTO = _mapper.Map<TDTO>(entity);
        return entityDTO;
    }

    public async Task<List<TDTO>> GetPeopleAsync(CancellationToken cancellation = default)
    {
        var prisoners = await _repository.GetAsync(null, cancellation);
        return prisoners.Select(entity => _mapper.Map<TDTO>(entity)).ToList();
    }

    public virtual async Task<OperationResult<TEntity>> UpdatePersonAsync(Guid id, TUpdateDTO updatedEntity, CancellationToken cancellation = default)
    {
        var result = new OperationResult<TEntity>();

        var entityDTO = GetPersonByIdAsync(id);
        var entity = _mapper.Map<TEntity>(entityDTO);

        await _uow.BeginTransactionAsync();

        try
        {
            // entity.Name = updatedEntity.Name;

            await _repository.Update(entity, cancellation);
            await _uow.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<TEntity>(
                new ResultMessage($"Failed to update user: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    // REFAZER ACIMA
}