using Domain.SeedWorks;

namespace Domain.Models;

public class TableCreateRequest : IValueObject
{
    public string OriginConnectionString { get; init; }
    public string OriginTableName { get; init; }
    
    public string DestinationConnectionString { get; init; }
    public string DestinationTableName { get; init; }
}