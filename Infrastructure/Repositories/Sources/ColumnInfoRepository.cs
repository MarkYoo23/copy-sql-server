using Dapper;
using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sources;

public class ColumnInfoRepository : ReadOnlyRepository<ColumnInfo>, IColumnInfoRepository
{
    private readonly SourceContext _context;

    public ColumnInfoRepository(SourceContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ColumnComputedInfo>> GetComputedAllAsync(string tableName)
    {
        // ReSharper disable once StringLiteralTypo
        var query = @$"
SELECT 
    COLUMN_NAME as Name, 
    COLUMNPROPERTY(OBJECT_ID('dbo' + '.' + '{tableName}'), COLUMN_NAME, 'IsComputed') as IsComputed 
FROM
    INFORMATION_SCHEMA.COLUMNS
WHERE
    TABLE_NAME = '{tableName}'";

        await using var dbConnection = new SqlConnection(_context.Database.GetConnectionString());
        await dbConnection.OpenAsync();

        var infos = await dbConnection.QueryAsync<ColumnComputedInfo>(query);

        await dbConnection.CloseAsync();
        await dbConnection.DisposeAsync();

        return infos;
    }
}
