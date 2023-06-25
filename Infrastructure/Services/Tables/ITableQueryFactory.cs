using Domain.Models.Masters;

namespace Infrastructure.Services.Tables;

public interface ITableQueryFactory
{
    string ToQuery(string name, IEnumerable<TableColumn> columns);
}
