namespace Domain.Models.Masters;

public class TableColumn
{
    public string Name { get; set; } = string.Empty;
    public string Datatype { get; set; }  = string.Empty;
    public int? StringLength { get; set; }
    public bool IsNullable { get; set; }
    public bool IsPrimaryKey { get; set; }
    public bool IsIdentity { get; set; }
    public string? ColumnDefault { get; set; }
}
