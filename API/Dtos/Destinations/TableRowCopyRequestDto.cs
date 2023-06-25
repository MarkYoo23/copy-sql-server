namespace API.Dtos.Destinations;

public class TableRowCopyRequestDto
{
    public string SourceTableName { get; set; } = string.Empty;
    public string DestinationTableName { get; set; }  = string.Empty;
}
