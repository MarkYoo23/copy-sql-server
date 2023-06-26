using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Domain.SeedWorks;

namespace Domain.Repositories.Sources;

public interface IColumnInfoRepository : IReadOnlyRepository<ColumnInfo>
{
    Task<IEnumerable<ColumnComputedInfo>> GetComputedAllAsync(string tableName);
}
