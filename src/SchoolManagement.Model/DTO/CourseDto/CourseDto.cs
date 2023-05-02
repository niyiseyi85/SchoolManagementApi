using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.DTO.CourseDto
{
  public class CourseDto
  {
    public string CousreTitle { get; set; }
    public string Code { get; set; }
    public int TeacherId { get; set; }    
  }
  public class CourseDtoRequestMappingConfig : Profile
  {
    public CourseDtoRequestMappingConfig()
    {
      CreateMap<CourseDto, CourseDto>().ReverseMap();
    }
  }
}
