using System.Text.Json.Serialization;
using API.Extensions;
using Application.Services;
using Domain.Models.Samples;
using Infrastructure.Contexts;
using Infrastructure.Services;
using Infrastructure.Services.Connections;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddApplicationDbContexts();
builder.Services.AddApplicationRepositories();
builder.Services.AddApplicationServices();

builder.Services
    .AddControllers(_ => { })
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var sampleContext = serviceProvider.GetRequiredService<SampleContext>();

    var cts = new CancellationTokenSource(5000);

    if (await sampleContext.Database.CanConnectAsync(cts.Token))
    {
        await sampleContext.Database.EnsureDeletedAsync(cts.Token);
    }

    await sampleContext.Database.EnsureCreatedAsync(cts.Token);
    
    sampleContext.Samples.Add(new Sample()
    {
        Title = "title",
        Content = "content",
    });
    await sampleContext.SaveChangesAsync();

    // Register SQL source...
    var registerResourceService = serviceProvider.GetRequiredService<RegisterResourceService>();
    await registerResourceService.ExecuteAsync(app.Environment.ContentRootPath);

    // Register connection source...
    var connectionSourceManager = serviceProvider.GetRequiredService<ConnectionSourceManager>();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    connectionSourceManager.Add(ConnectionSourceType.Source, configuration.GetConnectionString("Source")!);
    connectionSourceManager.Add(ConnectionSourceType.Destination, configuration.GetConnectionString("Destination")!);
}

app.Run();
