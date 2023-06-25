// ReSharper disable UnusedType.Global
// ReSharper disable UnusedTypeParameter
namespace Domain.SeedWorks;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
