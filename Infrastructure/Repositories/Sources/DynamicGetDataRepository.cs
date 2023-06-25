using System.Collections;
using System.Text;
using Dapper;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sources;

public class DynamicGetDataRepository : IDynamicGetDataRepository
{
    private readonly SourceContext _sourceContext;

    public DynamicGetDataRepository(SourceContext sourceContext)
    {
        _sourceContext = sourceContext;
    }

    public IEnumerable<IDictionary<string, object>> GetAll(string tableName, string? schemaName = null)
    {
        var connection = _sourceContext.Database.GetDbConnection();
        connection.Open();

        var queryString = CreateSelectAllQuery(tableName, schemaName);
        var query = connection.Query(queryString);

        var results = query.Select(row => row as IDictionary<string, object>).ToArray();
        return results!;
    }

    public async Task<IEnumerable<IDictionary<string, object>>> GetAllAsync(string tableName,
        string? schemaName = null)
    {
        var connection = _sourceContext.Database.GetDbConnection();
        await connection.OpenAsync();

        var queryString = CreateSelectAllQuery(tableName, schemaName);
        var query = await connection.QueryAsync(queryString);

        var results = query.Select(row => row as IDictionary<string, object>).ToArray();
        return results!;
    }

    private string CreateSelectAllQuery(string tableName, string? schemaName)
    {
        var tableNameWithSchemaName = TableNameHelper.CreateTableWithSchemaName(tableName, schemaName);
        return $"SELECT * FROM {tableNameWithSchemaName}";
    }
}
