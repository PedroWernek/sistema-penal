using PenalSystem.Entities.Abstractions;

namespace PenalSystem.Entities;

public class Book : Activity
{
    public required string Isbn { get; set; }
}