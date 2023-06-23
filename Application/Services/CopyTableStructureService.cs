using Domain.Models;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public class CopyTableStructureService
{
    private readonly ContextFactory _contextFactory;

    public CopyTableStructureService(ContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task ExecuteAsync(TableCreateRequest request)
    {
        await using var originContext = _contextFactory.Create<DbContext>(request.OriginConnectionString);
        var originTableRepository = OriginTableRepository.Create(originContext);
        
        var originTableInfo = await originTableRepository.GetAsync(request.OriginTableName);
    }
}