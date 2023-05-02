using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;

namespace SchoolManagement.Api.Configuration
{
  public static class DatabaseConfig
  {
    public static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
      services.AddScoped<DbContext, DataContext>();

      services.AddDbContext<DataContext>(options =>
          options.UseSqlServer(config.GetConnectionString("DbContext"),
          sqlServerOptionsAction: sqlOptions =>
          {
            sqlOptions.EnableRetryOnFailure();
          }));

    }


    public static void Configure(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<DataContext>();
      }
    }
  }
}
