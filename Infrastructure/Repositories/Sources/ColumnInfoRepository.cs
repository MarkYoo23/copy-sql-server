using System.Linq.Expressions;
using Domain.Models.Masters.Columns;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Sources;

public class ColumnInfoRepository : IColumnInfoRepository
{
    private readonly SourceContext _context;
    private readonly SqlManager _sqlManager;

    public ColumnInfoRepository(
        SourceContext context,
        SqlManager sqlManager)
    {
        _context = context;
        _sqlManager = sqlManager;
    }

    public IEnumerable<ColumnInfo> FindAll(string tableName)
    {
        var query = CreateQuery(tableName);
        var results = query.ToList();
        return results;
    }

    public async Task<IEnumerable<ColumnInfo>> FindAllAsync(string tableName)
    {
        var query = CreateQuery(tableName);
        var results = await query.ToListAsync();
        return results;
    }

    private IQueryable<ColumnInfo> CreateQuery(string tableName)
    {
        var builder = new SqlConnectionStringBuilder(_context.Database.GetConnectionString());
        
        var baseQuery = _sqlManager["SelectInformationSchemaColumnWithIsComputed.sql"]
            .Replace("{DATABASE_NAME}", builder.InitialCatalog);

        var tableNameParameter = new SqlParameter("@tableName", tableName);

        return _context.ColumnInfos.FromSqlRaw(baseQuery, tableNameParameter);
    }
}