using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Masters;

public class ColumnKeyInfoViewConfig : IEntityTypeConfiguration<ColumnKeyInfo>
{
    public void Configure(EntityTypeBuilder<ColumnKeyInfo> builder)
    {
        builder.ToTable("KEY_COLUMN_USAGE", SchemaNames.SystemInformationSchema);

        builder.HasNoKey();

        ConfigureColumns(builder);
    }

    private static void ConfigureColumns(EntityTypeBuilder<ColumnKeyInfo> builder)
    {
        builder.Property(c => c.ConstraintCatalog).HasColumnName("CONSTRAINT_CATALOG");
        builder.Property(c => c.ConstraintSchema).HasColumnName("CONSTRAINT_SCHEMA");
        builder.Property(c => c.ConstraintName).HasColumnName("CONSTRAINT_NAME");
        builder.Property(c => c.TableCatalog).HasColumnName("TABLE_CATALOG");
        builder.Property(c => c.TableSchema).HasColumnName("TABLE_SCHEMA");
        builder.Property(c => c.TableName).HasColumnName("TABLE_NAME");
        builder.Property(c => c.ColumnName).HasColumnName("COLUMN_NAME");
        builder.Property(c => c.OrdinalPosition).HasColumnName("ORDINAL_POSITION");
    }
}
