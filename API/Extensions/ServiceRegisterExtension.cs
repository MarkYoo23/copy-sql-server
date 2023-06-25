using Application.Services;
using Application.Services.Destinations;

namespace API.Extensions;

public static class ServiceRegisterExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // TODO : (dh) 아래 3개 클래스는 새로운 로직에 의해 대체 될 예정
        services.AddScoped<TableStructureReadService>();
        services.AddScoped<TableStructureCopyService>();
        services.AddScoped<RegisterResourceService>();
        
        services.AddScoped<RowsCopyOriginToDestinationService>();
    }
}
