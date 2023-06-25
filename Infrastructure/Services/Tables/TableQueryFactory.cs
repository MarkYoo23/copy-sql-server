using System.Text;
using Domain.Models.Masters;
using Infrastructure.Models;

namespace Infrastructure.Services.Tables;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable once ClassNeverInstantiated.Global

public class TableQueryFactory : ITableQueryFactory
{
    public string ToQuery(string name, IEnumerable<TableColumn> columns)
    {
        if (columns == null)
        {
            throw new NullReferenceException("column is can not null");
        }

        if (columns.Any() == false)
        {
            throw new Exception();
        }

        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"CREATE TABLE [{name}] (");

        foreach (var column in columns)
        {
            string columnDefinition = $"    [{column.Name}] [{column.Datatype}]";

            switch (column.StringLength)
            {
                case > 0 and < int.MaxValue:
                    columnDefinition += $"({column.StringLength})";
                    break;
                case < 0:
                    columnDefinition += $"(max)";
                    break;
            }

            columnDefinition += " " + (column.IsNullable ? "NULL" : "NOT NULL");

            if (column.IsIdentity)
            {
                switch (column.Datatype)
                {
                    case SqlDataTypeNames.Integer:
                    case SqlDataTypeNames.BigInteger:
                        columnDefinition += $" IDENTITY";
                        break;
                    default:
                        throw new NotSupportedException($"Identity not supported {column.Datatype}");
                }
            }

            columnDefinition += ",";

            stringBuilder.AppendLine(columnDefinition);
        }

        var primaryKeyColumn = columns.FirstOrDefault(column => column.IsPrimaryKey);
        if (primaryKeyColumn != null)
        {
            stringBuilder.AppendLine($"    CONSTRAINT [PK_{name}] PRIMARY KEY ([{primaryKeyColumn.Name}]),");
        }

        stringBuilder.Length--; // Remove the last comma
        stringBuilder.AppendLine(");");

        return stringBuilder.ToString();
    }
}
