using Domain.SeedWorks;
using static System.String;

namespace Domain.Models.Masters.Columns;

public class ColumnInfo : ValueObject
{
    public string TableCatalog { get; set; } = Empty;
    public string TableSchema { get; set; } = Empty;
    public string TableName { get; set; } = Empty;
    public string ColumnName { get; set; } = Empty;
    public int OrdinalPosition { get; set; }
    public string? ColumnDefault { get; set; } = Empty;
    public string IsNullable { get; set; } = Empty;
    public string DataType { get; set; } = Empty;
    public int? CharacterMaximumLength { get; set; }
    public int? CharacterOctetLength { get; set; }
    public byte? NumericPrecision { get; set; }
    public short? NumericPrecisionRadix { get; set; }
    public int? NumericScale { get; set; }
    public short? DateTimePrecision { get; set; }
    public string? CharacterSetCatalog { get; set; } = Empty;
    public string? CharacterSetSchema { get; set; } = Empty;
    public string? CharacterSetName { get; set; } = Empty;
    public string? CollationCatalog { get; set; } = Empty;
    public string? CollationSchema { get; set; } = Empty;
    public string? CollationName { get; set; } = Empty;
    public string? DomainCatalog { get; set; } = Empty;
    public string? DomainSchema { get; set; } = Empty;
    public string? DomainName { get; set; } = Empty;
    public bool IsComputed { get; set; }
}
