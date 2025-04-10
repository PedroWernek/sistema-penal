namespace PenalSystem.DTOs;

public abstract class PersonDTO : IDTO
{
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Cpf { get; set; }
}

public abstract class PersonCreateDTO : IDTO
{
    public override Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Cpf { get; set; }
}

public abstract class PersonUpdateDTO : IDTO
{
}