using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories.Sources;

public class ColumnKeyInfoRepository : ReadOnlyRepository<ColumnKeyInfo>, IColumnKeyInfoRepository
{
    public ColumnKeyInfoRepository(SourceContext dbContext) : base(dbContext)
    {
    }
}
