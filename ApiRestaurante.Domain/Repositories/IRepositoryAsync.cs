using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Domain.Repositories
{
    public interface IRepositoryAsync<T> : IDisposable where T : class
    {

        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> DeleteById(int id);
        Task<T> Delete(T entity);
    }
}
