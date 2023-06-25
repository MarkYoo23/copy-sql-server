namespace Domain.Repositories.Sources;

public interface IDynamicGetDataRepository
{
    IEnumerable<IDictionary<string, object>> GetAll(string tableName, string? schemaName = null);
    Task<IEnumerable<IDictionary<string, object>>> GetAllAsync(string tableName, string? schemaName = null);
}
