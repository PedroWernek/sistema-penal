using PenalSystem.Entities.Abstractions;

namespace PenalSystem.Entities;

public class Prisoner : Person
{
    public required string SentenceReason { get; set; }
    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
    public int BookCounter { get; set; }
    public int CurrentYear { get; set; }
    public bool IsLifeImprisonment { get; set; }

    public List<Book> Books { get; set; } = [];
    // public List<Study> Studies { get; set; } = [];
    // public List<WorkDay> DaysOfWork { get; set; } = [];
}

// TODO: adicionar a função de extended sentence