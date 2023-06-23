using Domain.Models;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OriginTableRepository : IOriginTableRepository
{
    private const string query = @"
DECLARE @sqlCommand NVARCHAR(MAX) = 'CREATE TABLE ' + @tableName + ' (' + CHAR(13) + CHAR(10)
DECLARE @columnName NVARCHAR(128)
DECLARE @dataType NVARCHAR(128)
DECLARE @maxLength INT
DECLARE @isNullable BIT
DECLARE @isIdentity BIT
DECLARE @isPrimaryKey BIT

SELECT cols.COLUMN_NAME
	,DATA_TYPE
	,CHARACTER_MAXIMUM_LENGTH
	,IS_NULLABLE
	,COLUMNPROPERTY(OBJECT_ID(cols.TABLE_SCHEMA + '.' + cols.TABLE_NAME), cols.COLUMN_NAME, 'IsIdentity') AS IsIdentity
	,(
		CASE 
			WHEN EXISTS (
					SELECT 1
					FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE as usage
					WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
						AND usage.TABLE_SCHEMA = kcu.TABLE_SCHEMA
						AND usage.TABLE_NAME = kcu.TABLE_NAME
						AND usage.COLUMN_NAME = kcu.COLUMN_NAME
					)
				THEN 1
			ELSE 0
			END
		) AS IsPrimaryKey
FROM INFORMATION_SCHEMA.COLUMNS as cols
LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu ON OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
	AND cols.TABLE_SCHEMA = kcu.TABLE_SCHEMA
	AND cols.TABLE_NAME = kcu.TABLE_NAME
	AND cols.COLUMN_NAME = kcu.COLUMN_NAME
WHERE cols.TABLE_NAME = @tableName
ORDER BY cols.ORDINAL_POSITION
";
    
    private readonly DbContext _context;

    public OriginTableRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TableRowInfo>> GetAsync(string tableName)
    {
	    var urlColumnValue = new SqlParameter("@tableName", tableName);	    
        return await _context.Database.SqlQueryRaw<TableRowInfo>(query, urlColumnValue).ToListAsync();
    }

    public static IOriginTableRepository Create(DbContext context)
    {
        return new OriginTableRepository(context);
    }
}