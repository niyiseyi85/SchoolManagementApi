using NLog.Fluent;
using NLog.Web;
using SchoolManagement.Api.Configuration;
using SchoolManagement.Data.IRepository;
using SchoolManagement.Data.Repository;


var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();


try
{
  var builder = WebApplication.CreateBuilder(args);

  // Add services to the container.
  // your other stuff.
  builder.Services.AddControllers();

  var services = builder.Services;
  var config = builder.Configuration;
  AutomapperConfig.Configure(services);
  DatabaseConfig.ConfigureServices(services, config);
  ServiceExtentionConfig.ConfigureServices(services);
  SwaggerConfig.ConfigureService(services);
  // NLog: Setup NLog for Dependency injection
  builder.Logging.ClearProviders();
  builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
  builder.Host.UseNLog();

  //other classes that need the logger 
  

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  // Other stuff
  if (app.Environment.IsDevelopment())
  {
    SwaggerConfig.Configure(app);
  }
  
  app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  app.Run();

}
catch (Exception exception)
{
  // NLog: catch setup errors
  logger.Error(exception, "Stopped program because of exception");
  throw;
}
finally
{
  // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
  NLog.LogManager.Shutdown();
}
