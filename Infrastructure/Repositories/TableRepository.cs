using Dapper;
using Domain.Models.Masters;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TableRepository : ITableRepository
{
    private readonly SourceContext _dbContext;
    private readonly SqlManager _sqlManager;

    public TableRepository(SourceContext dbContext, SqlManager sqlManager)
    {
        _dbContext = dbContext;
        _sqlManager = sqlManager;
    }

    public async Task<IEnumerable<TableColumn>> GetAsync(string tableName)
    {
        await using var connection = _dbContext.Database.GetDbConnection();

        var query = _sqlManager["GetColumnInfo.sql"];
        var tableColumns = await connection.QueryAsync<TableColumn>(query, new { TableName = tableName });
        return tableColumns;
    }

    public async Task<bool> CreateAsync(string name, IEnumerable<TableColumn> columns)
    {
        await using var connection = _dbContext.Database.GetDbConnection();
        throw new NotImplementedException("작업중");
    }
}
