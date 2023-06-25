using Infrastructure.Contexts;
using Infrastructure.Services;
using Infrastructure.Services.Connections;

namespace API.Extensions;

public static class DbContextExtensions
{
    public static void AddApplicationDbContexts(this IServiceCollection services)
    {
        services.AddSingleton<SqlManager>();
        services.AddSingleton<ContextFactory>();

        services.AddScoped<SampleContext>(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("sample")!;
            var contextFactory = serviceProvider.GetRequiredService<ContextFactory>();
            return contextFactory.Create<SampleContext>(connectionString);
        });

        services.AddSingleton<ConnectionSourceManager>();

        services.AddScoped<SourceContext>(serviceProvider
            => serviceProvider.CreateApplicationContext<SourceContext>(
                ConnectionSourceType.Source));

        services.AddScoped<DestinationContext>(serviceProvider
            => serviceProvider.CreateApplicationContext<DestinationContext>(
                ConnectionSourceType.Destination));
    }

    private static T CreateApplicationContext<T>(
        this IServiceProvider serviceProvider,
        ConnectionSourceType sourceType) where T : BaseContext
    {
        var connectionSourceManager = serviceProvider.GetRequiredService<ConnectionSourceManager>();
        var contextFactory = serviceProvider.GetRequiredService<ContextFactory>();
        var connectionString = connectionSourceManager[sourceType];
        return contextFactory.Create<T>(connectionString);
    }
}
