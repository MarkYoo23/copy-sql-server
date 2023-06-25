using API.Dtos.Destinations;
using Application.Models.Destinations;
using Application.Services.Destinations;
using Domain.Models.Masters.Tables;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Destinations;

[ApiController]
[Route("destination-table")]
public class DestinationTableController : ControllerBase
{
    [HttpPost("clear-values")]
    public void ClearTable()
    {

    }

    [HttpPost("copy-values")]
    public async Task<IActionResult> CopyValues(
        [FromServices] RowsCopyOriginToDestinationService service,
        [FromBody] TableRowCopyRequestDto request)
    {
        await service.ExecuteAsync(new RowCopyOriginToDestinationRequest
        {
            Origin = new TableName()
            {
                Name = request.SourceTableName,
                Schema = null,
            },
            Destination = new TableName()
            {
                Name = request.DestinationTableName,
                Schema = null,
            }
        });

        return Ok();
    }
}
