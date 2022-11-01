using Antix.Patient.Host.Properties;
using Antix.Patient.Host.Server;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
    .AddEnvironmentVariables()
    .Build()
    .Get<Settings>();

builder.Logging.AddFile();

builder.Services
    .ConfigureServer(settings);

var app = builder.Build();

app
    .UseHttpsRedirection()
    .UseServer()
    .UseDefaultFiles()
    .UseStaticFiles();

app.Run();

