using SchoolManagement.Data.IRepository;

namespace SchoolManagement.Data.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataContext _context;
    private ITeacherRepository _teacherRepository;
    private IManagementRepository _managementRepository;
    private ICourseRepository _courseRepository;
    private IStudentRepository _studentRepository;    
    public UnitOfWork(DataContext context, ITeacherRepository teacherRepository, IManagementRepository managementRepository, ICourseRepository courseRepository, IStudentRepository studentRepository)
    {
      _context = context;
      _teacherRepository = teacherRepository;
      _managementRepository = managementRepository;
      _courseRepository = courseRepository;
      _studentRepository = studentRepository;
    }

    public ITeacherRepository TeacherRepository => _teacherRepository ??= new TeacherRepository(_context);
    public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context);
    public IManagementRepository ManagementRepository => _managementRepository ??= new ManagementRepository(_context);
    public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(_context);

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
      _context.Dispose();
      GC.SuppressFinalize(this);
    }
  }
}
