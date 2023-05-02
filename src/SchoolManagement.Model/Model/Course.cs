using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Model
{
  public class Course
  {
    public int Id { get; set; }
    public string CousreTitle { get; set; }
    public string Code { get; set; }    
    public DateTime CreatedAt { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
  }
}
