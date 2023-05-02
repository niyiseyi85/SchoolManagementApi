using SchoolManagement.Data.IRepository;
using SchoolManagement.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.Repository
{
  public class StudentRepository : RepositoryGeneric<Student>, IStudentRepository
  {
    private readonly DataContext _db;
    public StudentRepository(DataContext context) : base(context)
    {
      _db = context;
    }
  }  
}
