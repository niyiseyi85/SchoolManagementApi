using CSharpFunctionalExtensions;
using SchoolManagement.Common.Model;
using SchoolManagement.Model.DTO.TeacherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.IServices
{
  public interface ITeacherService
  {
    Task<Result<ResponseModel<TeacherDto>>> GetTeacherByIdAsync(int Id);
    Task<Result<ResponseModel<List<TeacherDto>>>> GetAllTeacherAsync();
    Task<Result<ResponseModel>> CreateTeacherAsync(TeacherDto request);
  }
}
