using PenalSystem.Interfaces;

namespace PenalSystem.Entities.Abstractions;

public abstract class Activity : IEntity
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }
    public DateTime Date { get; set; }

    // public required Prisoner Prisoner { get; set; }
    // TODO: implementar a navegação
}