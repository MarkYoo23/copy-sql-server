using Domain.Repositories.Destinations;
using Domain.Repositories.Sources;
using Infrastructure.Repositories.Destinations;
using Infrastructure.Repositories.Sources;

namespace API.Extensions;

public static class RepositoryRegisterExtension
{
    public static void AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISystemObjectRepository, SystemObjectRepository>();
        services.AddScoped<IColumnInfoRepository, ColumnInfoRepository>();
        services.AddScoped<IColumnKeyInfoRepository, ColumnKeyInfoRepository>();
        services.AddScoped<IDynamicGetDataRepository, DynamicGetDataRepository>();
        services.AddScoped<IDynamicAddDataRepository, DynamicAddDataRepository>();

    }
}
