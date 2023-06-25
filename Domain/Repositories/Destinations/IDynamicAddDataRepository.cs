using Domain.Models.CopyData;

namespace Domain.Repositories.Destinations;

public interface IDynamicAddDataRepository
{
    Task AddAsync(Table table);
}
