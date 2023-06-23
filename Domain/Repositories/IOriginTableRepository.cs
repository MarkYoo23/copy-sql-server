using Domain.Models;

namespace Domain.Repositories;

public interface IOriginTableRepository
{
    Task<IEnumerable<TableRowInfo>> GetAsync(string tableName);
}