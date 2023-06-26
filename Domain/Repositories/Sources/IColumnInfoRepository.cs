using Domain.Models.Masters.Columns;

namespace Domain.Repositories.Sources;

public interface IColumnInfoRepository
{
    IEnumerable<ColumnInfo> FindAll(string tableName);
    Task<IEnumerable<ColumnInfo>> FindAllAsync(string tableName);
}
