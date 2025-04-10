// TODO: terminar isso depois de criar prisoner

using AutoMapper;
using PenalSystem.DTOs;
using PenalSystem.Entities;
using PenalSystem.Entities.Abstractions;
using PenalSystem.Enums;
using PenalSystem.Extensions;
using PenalSystem.Interfaces;
using PenalSystem.Interfaces.Base;

namespace PenalSystem.Services.Base;

public abstract class ActivityService<TEntity, TDTO, TCreateDTO, TRepository> : IActivityServiceBase<TEntity, TDTO, TCreateDTO>  
where TEntity : Activity where TDTO : ActivityDTO where TCreateDTO : ActivityCreateDTO where TRepository : IActivityRepositoryBase<TEntity>
{
    protected readonly TRepository _repository;
    protected readonly IPrisonerRepository _prisonerRepository;
    protected readonly IUnitOfWork _uow;
    protected readonly IMapper _mapper;

    protected ActivityService(IUnitOfWork uow, IMapper mapper, TRepository repository, IPrisonerRepository prisonerRepository)
    {
        _uow = uow;
        _mapper = mapper;
        _repository = repository;
        _prisonerRepository = prisonerRepository;
    }

    public async Task<List<TDTO>> GetActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        if (prisonerId == Guid.Empty)
            throw new ArgumentException("Invalid prisoner ID.");

        var entities = await _repository.GetActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return entities.Select(e => _mapper.Map<TDTO>(e)).ToList();
    }

    public async Task<List<TDTO>> GetActivitiesAsync(CancellationToken cancellation = default)
    {
        var books = await _repository.GetAsync(null, cancellation);
        return books.Select(e => _mapper.Map<TDTO>(e)).ToList();
    }

    // virtual porque Book tem lógica individual (esquema do Year)
    public virtual async Task<OperationResult<TEntity>> CreateActivityAsync(TCreateDTO entityCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<TEntity>();

        if (entityCreateDTO is null || entityCreateDTO.PrisonerId == Guid.Empty)
        {
            return new OperationResult<TEntity>(
                new ResultMessage("Invalid activity creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var prisoner = await ValidatePrisonerAsync(entityCreateDTO.PrisonerId);

            var entity = _mapper.Map<TEntity>(entityCreateDTO);
            entity.Prisoner = prisoner;

            await _repository.AddAsync(entity, cancellation);

            var entities = await GetActivitiesByPrisonerIdAsync(prisoner.Id);

            if (entities.Any(x => x.Date == DateTime.Today))
            {
                return new OperationResult<TEntity>(
                    new ResultMessage("Invalid entity creation request: Today's date has already been logged.", ResultTypes.Error));
            }

            if (entities.Count() % 3 == 0)
            {
                await ReducePrisonerPenalty(prisoner.Id, -1);
                await _prisonerRepository.Update(prisoner);
            }

            await _uow.CommitTransactionAsync();

            result = new OperationResult<TEntity> { Value = entity };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<TEntity>(
                new ResultMessage($"Failed to create activity: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    protected async Task<Prisoner> ValidatePrisonerAsync(Guid prisonerId)
    {
        var prisoner = await _prisonerRepository.GetByIdAsync(prisonerId);
        if (prisoner is null)
            throw new InvalidOperationException("Prisoner not found.");

        return prisoner;
    }

    protected async Task ReducePrisonerPenalty(Guid prisonerId, int daysReduced)
    {
        var prisoner = await ValidatePrisonerAsync(prisonerId);

        await _uow.BeginTransactionAsync();
        try
        {
            prisoner.UpdatedReleaseDate = prisoner.UpdatedReleaseDate.AddDays(daysReduced);

            await _prisonerRepository.Update(prisoner);
            await _uow.CommitTransactionAsync();
        }
        catch
        {
            await _uow.RollbackTransactionAsync();
            throw;
        }
    }
}