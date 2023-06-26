using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Masters;

public class ColumnInfoViewConfig : IEntityTypeConfiguration<ColumnInfo>
{
    public void Configure(EntityTypeBuilder<ColumnInfo> builder)
    {
        builder.ToView(null);

        builder.HasNoKey();

        ConfigureColumns(builder);
    }

    private static void ConfigureColumns(EntityTypeBuilder<ColumnInfo> builder)
    {
        builder.Property(c => c.TableCatalog).HasColumnName("TABLE_CATALOG");
        builder.Property(c => c.TableSchema).HasColumnName("TABLE_SCHEMA");
        builder.Property(c => c.TableName).HasColumnName("TABLE_NAME");
        builder.Property(c => c.ColumnName).HasColumnName("COLUMN_NAME");
        builder.Property(c => c.OrdinalPosition).HasColumnName("ORDINAL_POSITION");
        builder.Property(c => c.ColumnDefault).HasColumnName("COLUMN_DEFAULT");
        builder.Property(c => c.IsNullable).HasColumnName("IS_NULLABLE");
        builder.Property(c => c.DataType).HasColumnName("DATA_TYPE");
        builder.Property(c => c.CharacterMaximumLength).HasColumnName("CHARACTER_MAXIMUM_LENGTH");
        builder.Property(c => c.CharacterOctetLength).HasColumnName("CHARACTER_OCTET_LENGTH");
        builder.Property(c => c.NumericPrecision).HasColumnName("NUMERIC_PRECISION");
        builder.Property(c => c.NumericPrecisionRadix).HasColumnName("NUMERIC_PRECISION_RADIX");
        builder.Property(c => c.NumericScale).HasColumnName("NUMERIC_SCALE");
        builder.Property(c => c.DateTimePrecision).HasColumnName("DATETIME_PRECISION");
        builder.Property(c => c.CharacterSetCatalog).HasColumnName("CHARACTER_SET_CATALOG");
        builder.Property(c => c.CharacterSetSchema).HasColumnName("CHARACTER_SET_SCHEMA");
        builder.Property(c => c.CharacterSetName).HasColumnName("CHARACTER_SET_NAME");
        builder.Property(c => c.CollationCatalog).HasColumnName("COLLATION_CATALOG");
        builder.Property(c => c.CollationSchema).HasColumnName("COLLATION_SCHEMA");
        builder.Property(c => c.CollationName).HasColumnName("COLLATION_NAME");
        builder.Property(c => c.DomainCatalog).HasColumnName("DOMAIN_CATALOG");
        builder.Property(c => c.DomainSchema).HasColumnName("DOMAIN_SCHEMA");
        builder.Property(c => c.DomainName).HasColumnName("DOMAIN_NAME");
        builder.Property(c => c.IsComputed).HasColumnName("IS_COMPUTED");
    }
}