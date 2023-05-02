using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Data.IRepository;
using SchoolManagement.Model.Model;

namespace SchoolManagement.Data.Repository
{
  public class CourseRepository : RepositoryGeneric<Course>, ICourseRepository
  {
    private readonly DataContext _db;
    public CourseRepository(DataContext context) : base(context)
    {
      _db = context;
    }
  }
}

