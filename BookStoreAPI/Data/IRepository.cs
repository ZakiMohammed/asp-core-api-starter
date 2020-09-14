using System.Collections.Generic;

namespace BookStoreAPI.Data
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
