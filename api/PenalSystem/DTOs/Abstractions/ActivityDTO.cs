namespace PenalSystem.DTOs;

public abstract class ActivityDTO : IDTO
{
    public Guid PrisonerId { get; set; }
    public DateTime Date { get; set; }

    public required PrisonerDTO Prisoner { get; set; }
}

public abstract class ActivityCreateDTO : IDTO
{
    public override Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; } = DateTime.Today;
    public Guid PrisonerId { get; set; }
}