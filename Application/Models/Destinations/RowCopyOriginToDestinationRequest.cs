using Domain.Models.Masters.Tables;

namespace Application.Models.Destinations;

public class RowCopyOriginToDestinationRequest
{
    public TableName Origin { get; set; } = new();
    public TableName Destination { get; set; } = new();
}
