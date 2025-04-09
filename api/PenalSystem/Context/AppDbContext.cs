using Microsoft.EntityFrameworkCore;
// using PenalSystem.Entities;

namespace PenalSystem.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    // public required DbSet<Book> Books { get; set; }
    // public required DbSet<WorkDay> WorkDays { get; set; }
    // public required DbSet<Employee> Employees { get; set; }
    // public required DbSet<Prisoner> Prisoners { get; set; }
    // public required DbSet<Study> Studies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}