using Dapper;
using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sources;

public class ColumnInfoRepository : ReadOnlyRepository<ColumnInfo>, IColumnInfoRepository
{
    private readonly SourceContext _context;

    public ColumnInfoRepository(SourceContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ColumnComputedInfo>> GetComputed(string tableName)
    {
        // ReSharper disable once StringLiteralTypo
        var query = @$"
SELECT 
    COLUMN_NAME as ColumnName, 
    COLUMNPROPERTY(OBJECT_ID('dbo' + '.' + '{tableName}'), COLUMN_NAME, 'IsComputed') as IsComputed 
FROM
    INFORMATION_SCHEMA.COLUMNS
WHERE
    TABLE_NAME = '{tableName}'";

        var dbConnection = _context.Database.GetDbConnection();
        await dbConnection.OpenAsync();

        var infos = await dbConnection.QueryAsync<ColumnComputedInfo>(query);
        return infos;
    }
}
