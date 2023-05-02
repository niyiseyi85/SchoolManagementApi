namespace SchoolManagement.Api.Configuration
{
  public static class SwaggerConfig
  {
    public static void ConfigureService(IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

    }
    public static void Configure(IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }
  }
}
