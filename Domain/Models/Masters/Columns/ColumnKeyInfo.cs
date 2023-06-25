using Domain.SeedWorks;

namespace Domain.Models.Masters.Columns;

public class ColumnKeyInfo : ValueObject
{
    public string ConstraintCatalog { get; set; } = string.Empty;
    public string ConstraintSchema { get; set; } = string.Empty;
    public string ConstraintName { get; set; } = string.Empty;
    public string TableCatalog { get; set; } = string.Empty;
    public string TableSchema { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public string ColumnName { get; set; } = string.Empty;
    public int OrdinalPosition { get; set; }
}
