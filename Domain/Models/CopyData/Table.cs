using Domain.Models.Masters.Columns;
using Domain.Models.Masters.Tables;

namespace Domain.Models.CopyData;

public class Table
{
    public TableName Name { get; set; } = null!;
    public Column[] Columns { get; set; } = null!;
    public string[][] Data { get; set; } = null!;

    public static Table Create(
        TableName name,
        IEnumerable<ColumnInfo> columnInfos,
        IEnumerable<IDictionary<string, object>> sourceData)
    {
        var columns = columnInfos
            .Select(row => new Column()
            {
                Name = row.ColumnName,
            })
            .ToArray();

        var data = sourceData
            .Select(row => row.Values.Select(col => col.ToString()).ToArray())
            .ToArray();

        return new Table()
        {
            Name = name,
            Columns = columns,
            Data = data!,
        };
    }
}
