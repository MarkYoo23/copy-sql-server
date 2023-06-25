using Domain.Models.Samples;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class SampleContext : BaseContext
{
    public DbSet<Sample> Samples { get; set; } = null!;
    
    public SampleContext(DbContextOptions<SampleContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SampleEntityConfig());
    }
}