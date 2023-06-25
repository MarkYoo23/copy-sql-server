using Domain.Models.Masters;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Application.Services;

public class TableStructureReadService
{
    private readonly ContextFactory _contextFactory;
    private readonly SqlManager _sqlManager;

    public TableStructureReadService(
        ContextFactory contextFactory,
        SqlManager sqlManager)
    {
        _contextFactory = contextFactory;
        _sqlManager = sqlManager;
    }

    public async Task<IEnumerable<TableColumn>> ExecuteAsync(string connectionString, string tableName)
    {
        await using var context = _contextFactory.Create<SourceContext>(connectionString);
        var repository = new TableRepository(context, _sqlManager);
        var tableColumns = await repository.GetAsync(tableName);
        return tableColumns;
    }
}
