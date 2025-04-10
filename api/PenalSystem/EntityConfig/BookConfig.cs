using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PenalSystem.Entities;

namespace PenalSystem.EntityConfig;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.PrisonerId).IsRequired();

        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.Isbn).HasMaxLength(11).IsFixedLength().IsRequired();
        
        builder.HasOne(x => x.Prisoner).WithMany(x => x.Books).IsRequired();
    }
}