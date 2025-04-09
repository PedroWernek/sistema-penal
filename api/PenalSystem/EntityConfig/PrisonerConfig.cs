using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Entities;

namespace PenalSystem.Configurations;

internal class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
{
    public void Configure(EntityTypeBuilder<Prisoner> builder)
    {
        builder.ToTable("Prisoners").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("Birth Date").IsRequired();
        builder.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(11).IsFixedLength().IsRequired();
        builder.Property(x => x.ArrivalDay).HasColumnName("Arrival Date").IsRequired();
        builder.Property(x => x.OriginalReleaseDate).HasColumnName("Original Release Date").IsRequired();
        builder.Property(x => x.UpdatedReleaseDate).HasColumnName("Updated Release Date").IsRequired();
        builder.Property(x => x.BookCounter).HasColumnName("Books Counter").IsRequired();
        builder.Property(x => x.CurrentYear).HasColumnName("Current Year").IsRequired();

        // builder.HasMany(x => x.Books).WithOne(x => x.Prisoner).IsRequired();
        // builder.HasMany(x => x.Studies).WithOne(x => x.Prisoner).IsRequired();
        // builder.HasMany(x => x.DaysOfWork).WithOne(x => x.Prisoner).IsRequired();
    }
}