using AutoMapper;
using PenalSystem.DTOs;
using PenalSystem.Entities;
using PenalSystem.Interfaces;

namespace PenalSystem.Services;

public class PrisonerService : PersonService<Prisoner, PrisonerDTO, PrisonerCreateDTO, PrisonerUpdateDTO, IPrisonerRepository>, IPrisonerService
{
    public PrisonerService(IPrisonerRepository repository, IUnitOfWork uow, IMapper mapper) : 
    base(repository, uow, mapper)
    {
    }
}