using SchoolManagement.Data.IRepository;
using SchoolManagement.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repository
{
  public class TeacherRepository : RepositoryGeneric<Teacher>, ITeacherRepository
  {
    private readonly DataContext _db;
    public TeacherRepository(DataContext context) : base(context)
    {
      _db = context;
    }
  }  
}
