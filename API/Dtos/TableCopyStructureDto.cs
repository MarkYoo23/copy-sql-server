namespace API.Dtos;

public class TableCopyStructureDto
{
    public string OriginConnectionString { get; init; }
    public string DestinationConnectionString { get; init; }
    public string TableName { get; init; }
}