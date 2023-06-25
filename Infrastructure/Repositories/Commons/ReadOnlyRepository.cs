using System.Linq.Expressions;
using Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Commons;

public abstract class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : ValueObject
{
    private readonly DbContext _context;

    protected ReadOnlyRepository(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        => _context.Set<T>().Where(expression).ToList();

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        => await _context.Set<T>().Where(expression).ToListAsync();
}
