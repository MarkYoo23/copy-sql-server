using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class MasterContext : DbContext
{

    public MasterContext(DbContextOptions<MasterContext> options)
    {
    }
    
}