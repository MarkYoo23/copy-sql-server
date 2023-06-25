using Domain.Models.Masters;
using Domain.Repositories.Sources;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories.Sources;

public class SystemObjectRepository
    : ReadOnlyRepository<SystemObject>, ISystemObjectRepository
{
    public SystemObjectRepository(SourceContext context) : base(context)
    {
    }
}
