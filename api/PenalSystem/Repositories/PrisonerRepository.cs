using PenalSystem.Entities;
using PenalSystem.Interfaces;
using PenalSystem.Context;

namespace PenalSystem.Repositories;

public class PrisonerRepository : PersonRepositoryBase<Prisoner>, IPrisonerRepository
{
    public PrisonerRepository(AppDbContext appContext) : base(appContext)
    {
    }
}