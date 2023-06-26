using System.Text;
using Dapper;
using Domain.Models.CopyData;
using Domain.Repositories.Destinations;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Destinations;

public class DynamicAddDataRepository : IDynamicAddDataRepository
{
    private readonly DestinationContext _context;

    public DynamicAddDataRepository(DestinationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Table table)
    {
        var tableName = TableNameHelper.CreateTableWithSchemaName(
            table.Name.Name,
            table.Name.Schema);

        var builder = new StringBuilder();
        builder.AppendLine($"SET IDENTITY_INSERT {tableName} ON");

        // INSERT COLUMNS
        var columnQuires = table.Columns
            .Where(row => !row.IsComputed)
            .Select(row => $"[{row.Name}], ")
            .ToList();

        builder.Append($"INSERT INTO {tableName} (");
        columnQuires.ForEach(row => builder.Append(row));
        builder.Length -= 2;
        builder.AppendLine(")");

        builder.AppendLine("VALUES");

        foreach (var row in table.Data)
        {
            var rowBuilder = new StringBuilder();
            rowBuilder.Append('(');

            for (int i = 0; i < row.Length; i++)
            {
                var colInfo = table.Columns[i];

                if (colInfo.IsComputed)
                {
                    continue;
                }

                var colData = row[i];
                var colDataType = colData.GetType();

                if (colDataType == typeof(DateTime))
                {
                    rowBuilder.Append($"'{colData:yyyy/MM/dd hh:mm:ss}', ");
                }
                else
                {
                    rowBuilder.Append($"'{colData}', ");
                }
            }

            rowBuilder.Length -= 2;
            rowBuilder.Append("),");

            // remove ,
            builder.AppendLine(rowBuilder.ToString());
        }

        builder.Length -= 2;
        builder.AppendLine();

        builder.AppendLine($"SET IDENTITY_INSERT {tableName} OFF");
        var query = builder.ToString();

        await using var connection = new SqlConnection(_context.Database.GetConnectionString());
        await connection.OpenAsync();

        await connection.ExecuteAsync(query);
    }
}
