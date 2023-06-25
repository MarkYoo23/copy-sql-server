using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DestinationContext : BaseContext
{
    public DestinationContext(DbContextOptions options) : base(options)
    {
    }
}
