using Domain.Models;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Application.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public class TableStructureCopyService
{
    private readonly ContextFactory _contextFactory;
    private readonly SqlManager _sqlManager;

    public TableStructureCopyService(
        ContextFactory contextFactory,
        SqlManager sqlManager)
    {
        _contextFactory = contextFactory;
        _sqlManager = sqlManager;
    }

    public async Task ExecuteAsync(TableCreateRequest request)
    {
        await using var context = _contextFactory.Create<SourceContext>(request.OriginConnectionString);
        var repository = new TableRepository(context, _sqlManager);
        var _ = await repository.GetAsync(request.OriginTableName);
    }
}
