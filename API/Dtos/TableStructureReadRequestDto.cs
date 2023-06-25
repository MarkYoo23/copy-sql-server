namespace API.Dtos;

public class TableStructureReadRequestDto
{
    public string ConnectionString { get; init; } = string.Empty;
    public string TableName { get; init; } = string.Empty;
}
