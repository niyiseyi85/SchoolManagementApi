using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.DTO.StudentDto
{
  public class StudentDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
  public class StudentDtoRequestMappingConfig : Profile
  {
    public StudentDtoRequestMappingConfig()
    {
      CreateMap<StudentDto, StudentDto>().ReverseMap();
    }
  }
}
