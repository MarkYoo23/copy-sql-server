using System.Net;
using Infrastructure.Services.Connections;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Configs;

[ApiController]
[Route("connection-sources")]
public class ConnectionSourceController : ControllerBase
{
    private readonly ConnectionSourceManager _connectionSourceManager;

    public ConnectionSourceController(ConnectionSourceManager connectionSourceManager)
    {
        _connectionSourceManager = connectionSourceManager;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var values = _connectionSourceManager.Values.ToList();
        return Ok(values);
    }

    [HttpGet("{connectionSourceType}")]
    public IActionResult Get([FromRoute] ConnectionSourceType connectionSourceType)
    {
        var isGet = _connectionSourceManager.TryGetValue(
            connectionSourceType, out var value);
        if (!isGet)
        {
            return BadRequest();
        }

        return Ok(value);
    }

    [HttpPost("{connectionSourceType}")]
    public IActionResult Add(
        [FromRoute] ConnectionSourceType connectionSourceType,
        [FromQuery] string connectionString)
    {
        var isAdd = _connectionSourceManager.TryAdd(
            connectionSourceType, connectionString);
        if (isAdd!)
        {
            return BadRequest();
        }

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPatch("{connectionSourceType}")]
    public IActionResult Update(
        [FromRoute] ConnectionSourceType connectionSourceType,
        [FromQuery] string connectionString)
    {
        if (!_connectionSourceManager.ContainsKey(connectionSourceType))
        {
        }

        _connectionSourceManager.Remove(connectionSourceType);

        var isAdd = _connectionSourceManager.TryAdd(
            connectionSourceType, connectionString);
        if (isAdd!)
        {
            return BadRequest();
        }

        return Ok();
    }
}
