namespace SchoolManagement.Data.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    ITeacherRepository TeacherRepository { get; }
    IStudentRepository StudentRepository { get; }
    IManagementRepository ManagementRepository { get; }
    ICourseRepository CourseRepository { get; }
    Task SaveAsync();
  }
}
