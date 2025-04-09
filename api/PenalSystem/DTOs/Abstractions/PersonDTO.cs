namespace PenalSystem.DTOs;

public abstract class PersonDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Cpf { get; set; }
}

public abstract class PersonCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Cpf { get; set; }
}