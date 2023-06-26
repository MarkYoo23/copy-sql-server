using Domain.Models.Masters.Columns;
using Domain.Models.Masters.Tables;

namespace Domain.Models.CopyData;

public class Table
{
    public TableName Name { get; set; } = null!;
    public ColumnInfo[] Columns { get; set; } = null!;
    public object[][] Data { get; set; } = null!;

    public static Table Create(
        TableName name,
        IEnumerable<ColumnInfo> columns,
        IEnumerable<IDictionary<string, object>> sourceData)
    {

        var data = sourceData
            .Select(row => row.Values.Select(col => col).ToArray())
            .ToArray();

        return new Table()
        {
            Name = name,
            Columns = columns.ToArray(),
            Data = data!,
        };
    }
}