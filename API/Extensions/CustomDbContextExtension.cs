

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Extensions;

public static class CustomDbContextExtension
{
    public static void AddLoggerFactoryDbContext<T>(this IServiceCollection services,
        string connectionString) where T : DbContext
    {
        services.AddScoped<T>(serviceProvider =>
        {
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<T>();
            var optionsBuilder = dbContextOptionsBuilder.UseSqlServer(connectionString)
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .ConfigureWarnings(configurationBuilder => configurationBuilder.Log(
                    (RelationalEventId.TransactionStarted, LogLevel.Information),
                    (RelationalEventId.TransactionCommitted, LogLevel.Information),
                    (RelationalEventId.TransactionRolledBack, LogLevel.Information)))
                .UseLoggerFactory(loggerFactory);

            return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options)!;
        });
    }

    public static void AddLogToDbContext<T>(
        this IServiceCollection services,
        string connectionString) where T : DbContext
    {
        services.AddScoped<T>(_ =>
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<T>();
            var optionsBuilder = dbContextOptionsBuilder.UseSqlServer(connectionString)
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .ConfigureWarnings(configurationBuilder => configurationBuilder.Log(
                    (RelationalEventId.TransactionStarted, LogLevel.Information),
                    (RelationalEventId.TransactionCommitted, LogLevel.Information),
                    (RelationalEventId.TransactionRolledBack, LogLevel.Information)))
                .LogTo(Console.WriteLine, LogLevel.Debug);

            return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options)!;
        });
    }
}