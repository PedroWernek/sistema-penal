namespace PenalSystem.DTOs;

public abstract class ActivityDTO
{
    public Guid Id { get; set; }
    public Guid PrisonerId { get; set; }
    public DateTime Date { get; set; }

    // public required PrisonerDTO Prisoner { get; set; }
}

public abstract class ActivityCreateDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; } = DateTime.Today;
    public Guid PrisonerId { get; set; }
}