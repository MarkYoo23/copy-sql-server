using API.Dtos;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TableCopyController : ControllerBase
{
    private readonly ILogger<TableCopyController> _logger;
    private readonly CopyTableStructureService _copyTableStructureService;

    public TableCopyController(
        ILogger<TableCopyController> logger,
        CopyTableStructureService copyTableStructureService)
    {
        _logger = logger;
        _copyTableStructureService = copyTableStructureService;
    }

    [HttpPost("Structure")]
    public async Task<IActionResult> Get([FromBody] TableCopyStructureDto requestBody)
    {
        var request = new TableCreateRequest()
        {
            OriginConnectionString = requestBody.OriginConnectionString,
            OriginTableName = requestBody.TableName,
            DestinationConnectionString = requestBody.OriginConnectionString,
            DestinationTableName = requestBody.TableName,
        };
        
        await _copyTableStructureService.ExecuteAsync(request);

        return Ok();
    }
}