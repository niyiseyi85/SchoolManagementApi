using SchoolManagement.Model.DTO.CourseDto;
using SchoolManagement.Model.DTO.ManagementDto;
using SchoolManagement.Model.DTO.StudentDto;
using SchoolManagement.Model.DTO.TeacherDto;
using System.Reflection;

namespace SchoolManagement.Api.Configuration
{
  public class AutomapperConfig
  {
    public static void Configure(IServiceCollection services, params Assembly[] additionalAssemblies)
    {
      services.AddAutoMapper(typeof(CourseDtoRequestMappingConfig));
      services.AddAutoMapper(typeof(TeacherDtoRequestMappingConfig));
      services.AddAutoMapper(typeof(StudentDtoRequestMappingConfig));
      services.AddAutoMapper(typeof(AdminDtoRequestMappingConfig));
    }
  }
}
