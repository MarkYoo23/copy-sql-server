using Domain.Repositories.Sources;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Sources;

[ApiController]
[Route("column-key-information")]
public class ColumnKeyInfoController : ControllerBase
{
    private readonly IColumnKeyInfoRepository _repository;

    public ColumnKeyInfoController(IColumnKeyInfoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var valueObjects = await _repository.GetAllAsync();
        return Ok(valueObjects);
    }

    [HttpGet("{tableName}")]
    public async Task<IActionResult> GetAllByTable([FromRoute] string tableName)
    {
        var valueObjects = await _repository.FindAllAsync(
            row => row.TableName == tableName);
        return Ok(valueObjects);
    }
}
