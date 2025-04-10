namespace PenalSystem.DTOs;

public class PrisonerDTO : PersonDTO
{
    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
    public int BookCounter { get; set; }
    public int CurrentYear { get; set; }

    public List<BookDTO> Books { get; set; } = [];
    // public List<StudyDTO> Studies { get; set; } = [];
    // public List<WorkDayDTO> DaysOfWork { get; set; } = [];
}

public class PrisonerOnlyDTO : PersonDTO
{
    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
}

public class PrisonerCreateDTO : PersonCreateDTO
{
    public int BookCounter { get; set; } = 0;
    public int CurrentYear { get; set; } = DateTime.Now.Year;

    public DateTime ArrivalDay { get; set; }
    public DateTime OriginalReleaseDate { get; set; }
    public DateTime UpdatedReleaseDate { get; set; }
}

public class PrisonerUpdateDTO : PersonUpdateDTO
{
    public required string Name { get; set; }
}