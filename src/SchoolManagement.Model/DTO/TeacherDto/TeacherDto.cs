using AutoMapper;
using SchoolManagement.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.DTO.TeacherDto
{
  public class TeacherDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int ManagementId { get; set; }
  }
  public class TeacherDtoRequestMappingConfig : Profile
  {
    public TeacherDtoRequestMappingConfig()
    {
      CreateMap<Teacher, TeacherDto>().ReverseMap();
    }
  }
}
