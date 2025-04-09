namespace PenalSystem.DTOs;

public class BookDTO : ActivityDTO
{
    public required string Isbn { get; set; }
}

public class BookCreateDTO : ActivityCreateDTO
{
    public required string Isbn { get; set; }
}