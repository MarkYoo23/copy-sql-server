using Domain.Models.Samples;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class SampleEntityConfig : IEntityTypeConfiguration<Sample>
{
    public void Configure(EntityTypeBuilder<Sample> builder)
    {
        builder.ToTable("sample");
        ConfigColumns(builder);
    }

    private static void ConfigColumns(EntityTypeBuilder<Sample> builder)
    {
        builder.HasKey(sample => sample.Id);

        builder.Property(sample => sample.Created)
            .HasDefaultValueSql(SqlFunctions.GetDate);

        builder.Property(sample => sample.CurrentDateTime)
            .HasComputedColumnSql(SqlFunctions.GetDate);
    }
}
