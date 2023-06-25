using System.Text;

namespace Infrastructure.Helpers;

public class TableNameHelper
{
    public static string CreateTableWithSchemaName(string tableName, string? schemaName)
    {
        var builder = new StringBuilder();
        if (schemaName != null)
        {
            builder.Append($"[{schemaName}].");
        }

        builder.Append($"[{tableName}]");
        return builder.ToString();
    }
}
