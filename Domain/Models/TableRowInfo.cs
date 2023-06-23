using System.ComponentModel.DataAnnotations.Schema;
using Domain.SeedWorks;

namespace Domain.Models;

public class TableRowInfo : IValueObject
{
    [Column("COLUMN_NAME")]
    public string ColumnName { get; set; }
    
    [Column("DATA_TYPE")]
    public string DataType { get; set; }
    
    [Column("CHARACTER_MAXIMUM_LENGTH")]
    public string? MaxLength  { get; set; }
    
    [Column("IS_NULLABLE")]
    public string IsNullable { get; set; }
    
    [Column("IsIdentity")]
    public bool IsIdentity { get; set; }
    
    [Column("IsPrimaryKey")]
    public bool IsPrimaryKey { get; set; }
}