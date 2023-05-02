using CSharpFunctionalExtensions;
using SchoolManagement.Common.Model;
using SchoolManagement.Model.DTO.ManagementDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.IServices
{
  public interface IManagementService
  {
    Task<Result<ResponseModel<AdminDto>>> GetAdminByIdAsync(int Id);
    Task<Result<ResponseModel<List<AdminDto>>>> GetAllAdminAsync();
    Task<Result<ResponseModel>> CreateAdminAsync(AdminDto request);
  }
}
