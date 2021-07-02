using System.Collections.Generic;

namespace simple_crud_console_app.Interfaces
{
  public interface IRepository<T>
  {
    List<T> List();
		List<T> ListNotDeleted();
    T GetByID(int id);
    void Insert(T entity);
    void Update(int id, T entity);
    void Delete(int id);
    int NextID();
  }
}