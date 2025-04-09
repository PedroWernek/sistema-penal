using PenalSystem.DTOs;
using PenalSystem.Entities;
using PenalSystem.Interfaces.Base;

namespace PenalSystem.Interfaces;

public interface IPrisonerService : IPersonServiceBase<Prisoner, PrisonerDTO, PrisonerCreateDTO, PrisonerUpdateDTO>
{
}