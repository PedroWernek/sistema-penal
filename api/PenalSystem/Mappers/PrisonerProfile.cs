using AutoMapper;
using PenalSystem.DTOs;
using PenalSystem.Entities;

namespace PenalSystem.Mappers;

public class PrisonerProfile : Profile
{
    public PrisonerProfile()
    {
        CreateMap<Prisoner, PrisonerDTO>();
        CreateMap<Prisoner, PrisonerOnlyDTO>();
        CreateMap<Prisoner, PrisonerCreateDTO>();
        CreateMap<Prisoner, PrisonerUpdateDTO>();

        CreateMap<PrisonerDTO, PrisonerCreateDTO>();
        CreateMap<PrisonerDTO, PrisonerUpdateDTO>();
        CreateMap<PrisonerDTO, Prisoner>();

        CreateMap<PrisonerCreateDTO, Prisoner>();

        CreateMap<PrisonerUpdateDTO, Prisoner>();
    }
}