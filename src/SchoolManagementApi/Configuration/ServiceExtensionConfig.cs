using SchoolManagement.Data.IRepository;
using SchoolManagement.Data.Repository;
using SchoolManagement.Service.IServices;
using SchoolManagement.Service.Services;

namespace SchoolManagement.Api.Configuration
{
  public static class ServiceExtentionConfig
  {
    public static void ConfigureServices(IServiceCollection services)
    {
      // Repository
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddTransient<IManagementRepository, ManagementRepository>();
      services.AddTransient<ICourseRepository, CourseRepository>();
      services.AddTransient<IStudentRepository, StudentRepository>();
      services.AddTransient<ITeacherRepository, TeacherRepository>();
      services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));


      //Services
      services.AddScoped<ITeacherService, TeacherService>();
      services.AddScoped<ICourseService, CourseService>();
      services.AddScoped<IManagementService, ManagementService>();
      services.AddScoped<IStudentService, StudentService>();
    }
  }
}