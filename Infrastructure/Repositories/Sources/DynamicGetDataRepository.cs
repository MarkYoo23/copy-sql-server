using System.Collections;
using System.Text;
using Dapper;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sources;

public class DynamicGetDataRepository : IDynamicGetDataRepository
{
    private readonly SourceContext _context;

    public DynamicGetDataRepository(SourceContext context)
    {
        _context = context;
    }

    public IEnumerable<IDictionary<string, object>> GetAll(string tableName, string? schemaName = null)
    {
        var connection = _context.Database.GetDbConnection();
        connection.Open();

        var queryString = CreateSelectAllQuery(tableName, schemaName);
        var query = connection.Query(queryString);

        var results = query.Select(row => row as IDictionary<string, object>).ToArray();
        return results!;
    }

    public async Task<IEnumerable<IDictionary<string, object>>> GetAllAsync(string tableName,
        string? schemaName = null)
    {
        await using var connection = new SqlConnection(_context.Database.GetConnectionString());
        await connection.OpenAsync();

        var queryString = CreateSelectAllQuery(tableName, schemaName);
        var query = await connection.QueryAsync(queryString);

        var results = query.Select(row => row as IDictionary<string, object>).ToArray();

        await connection.CloseAsync();
        
        return results!;
    }

    private string CreateSelectAllQuery(string tableName, string? schemaName)
    {
        var tableNameWithSchemaName = TableNameHelper.CreateTableWithSchemaName(tableName, schemaName);
        return $"SELECT * FROM {tableNameWithSchemaName}";
    }
}
