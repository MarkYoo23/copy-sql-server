using Domain.Repositories.Sources;
using Infrastructure.Models.Masters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Sources;

[ApiController]
[Route("database-information")]
public class DatabaseInfoController : ControllerBase
{
    [HttpGet("system-objects")]
    public async Task<IActionResult> GetSystemObjectsAsync(
        [FromServices] ISystemObjectRepository repository)
    {
        var valueObjects = await repository.GetAllAsync();
        return Ok(valueObjects);
    }

    [HttpGet("system-objects/user-tables")]
    public async Task<IActionResult> GetSystemObjectsOfUserTablesAsync(
        [FromServices] ISystemObjectRepository repository)
    {
        var valueObjects = await repository.FindAllAsync(
            row => row.Type == SystemObjectTypes.UserTable);
        return Ok(valueObjects);
    }

    [HttpGet("system-objects/primary-key")]
    public async Task<IActionResult> GetSystemObjectsOfUserTablesWithPrimaryKeyAsync(
        [FromServices] ISystemObjectRepository repository,
        [FromQuery] string tableName)
    {
        var valueObjects = await repository.FindAllAsync(
            row => row.Type == SystemObjectTypes.PrimaryKey);
        return Ok(valueObjects);
    }
}
