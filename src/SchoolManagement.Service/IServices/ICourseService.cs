using CSharpFunctionalExtensions;
using SchoolManagement.Common.Model;
using SchoolManagement.Model.DTO.CourseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.IServices
{
  public interface ICourseService
  {
    Task<Result<ResponseModel<CourseDto>>> GetCourseByIdAsync(int Id);
    Task<Result<ResponseModel<List<CourseDto>>>> GetAllCourseAsync();
    Task<Result<ResponseModel>> CreateCourseAsync(CourseDto request);
  }
}
