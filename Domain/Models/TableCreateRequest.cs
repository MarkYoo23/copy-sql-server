using Domain.SeedWorks;

namespace Domain.Models;

public class TableCreateRequest : ValueObject
{
    public string OriginConnectionString { get; init; } = string.Empty;
    public string OriginTableName { get; init; } = string.Empty;
    public string DestinationConnectionString { get; init; } = string.Empty;
    public string DestinationTableName { get; init; } = string.Empty;
}
