using Domain.Models.Masters;
using Domain.Models.Masters.Columns;
using Infrastructure.EntityConfigurations.Masters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class SourceContext : BaseContext
{
    // system schema
    public DbSet<SystemObject> SystemObjects { get; set; } = null!;

    // information schema
    public DbSet<ColumnInfo> ColumnInfos { get; set; } = null!;
    public DbSet<ColumnKeyInfo> ColumnKeyInfos { get; set; } = null!;

    public SourceContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SystemObjectViewConfig());

        modelBuilder.ApplyConfiguration(new ColumnInfoViewConfig());
        modelBuilder.ApplyConfiguration(new ColumnKeyInfoViewConfig());
    }
}
