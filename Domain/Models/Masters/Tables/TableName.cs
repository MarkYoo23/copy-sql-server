using Domain.SeedWorks;

namespace Domain.Models.Masters.Tables;

public class TableName : ValueObject
{
    public string Name { get; set; } = string.Empty;
    public string? Schema { get; set; } = string.Empty;
}
