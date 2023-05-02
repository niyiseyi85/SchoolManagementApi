using CSharpFunctionalExtensions;
using SchoolManagement.Common.Model;
using SchoolManagement.Model.DTO.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.IServices
{
  public interface IStudentService
  {
    Task<Result<ResponseModel<StudentDto>>> GetStudentByIdAsync(int Id);
    Task<Result<ResponseModel<List<StudentDto>>>> GetAllStudentAsync();
    Task<Result<ResponseModel>> CreateStudentAsync(StudentDto request);
  }
}
