using SchoolManagement.Data.IRepository;
using SchoolManagement.Model.Model;

namespace SchoolManagement.Data.Repository
{
  public class ManagementRepository : RepositoryGeneric<Management>, IManagementRepository
  {
    private readonly DataContext _db;
    public ManagementRepository(DataContext context) : base(context)
    {
      _db = context;
    }
  }
}
