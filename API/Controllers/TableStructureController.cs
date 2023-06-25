using API.Dtos;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TableStructureController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] TableStructureReadService tableStructureReadService,
        [FromQuery] TableStructureReadRequestDto requestBody)
    {
        var tableColumns = await tableStructureReadService.ExecuteAsync(
            requestBody.ConnectionString,
            requestBody.TableName);

        return Ok(tableColumns);
    }

    [HttpPost]
    public async Task<IActionResult> Put(
        [FromServices] TableStructureCopyService tableStructureCopyService,
        [FromBody] TableStructureCopyRequestDto requestBody)
    {
        var request = new TableCreateRequest()
        {
            OriginConnectionString = requestBody.OriginConnectionString,
            OriginTableName = requestBody.OriginTableName,
            DestinationConnectionString = requestBody.OriginConnectionString,
            DestinationTableName = (requestBody.DestinationTableName) ?? requestBody.OriginTableName,
        };

        await tableStructureCopyService.ExecuteAsync(request);

        return Ok();
    }
}
