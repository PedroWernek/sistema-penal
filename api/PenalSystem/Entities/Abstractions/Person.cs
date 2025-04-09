using PenalSystem.Interfaces;

namespace PenalSystem.Entities.Abstractions;

public abstract class Person : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Cpf { get; set; }
}