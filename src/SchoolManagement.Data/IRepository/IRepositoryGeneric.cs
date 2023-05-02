using System.Linq.Expressions;

namespace SchoolManagement.Data.IRepository
{
  public interface IRepositoryGeneric<T>
        where T : class
  {
    
      Task<T> Get(int id);

      Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
          IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

      Task<T> FirstOrDefault(
          Expression<Func<T, bool>> filter = null,
          string includeProperties = null);     

      Task<T> Add(T entity);
  }
}
