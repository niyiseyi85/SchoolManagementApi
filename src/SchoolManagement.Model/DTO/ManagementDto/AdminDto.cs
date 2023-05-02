using AutoMapper;
using SchoolManagement.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.DTO.ManagementDto
{
  public class AdminDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
  public class AdminDtoRequestMappingConfig : Profile
  {
    public AdminDtoRequestMappingConfig()
    {
      CreateMap<Management, AdminDto>().ReverseMap();
    }
  }
}
