using Domain.Repositories.Sources;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Sources;

[ApiController]
[Route("column-information")]
public class ColumnInfoController : ControllerBase
{
    private readonly IColumnInfoRepository _repository;

    public ColumnInfoController(IColumnInfoRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("{tableName}")]
    public async Task<IActionResult> GetAllByTable([FromRoute] string tableName)
    {
        var valueObjects = await _repository.FindAllAsync(tableName);
        return Ok(valueObjects);
    }
}
