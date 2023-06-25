namespace API.Dtos;

public class TableStructureCopyRequestDto
{
    public string OriginConnectionString { get; init; } = string.Empty;
    public string OriginTableName { get; init; } = string.Empty;

    public string DestinationConnectionString { get; init; } = string.Empty;
    public string? DestinationTableName { get; init; }

}
