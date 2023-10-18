using ApiRestaurante.Data.ConfigurationBD;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Domain.Repositories.Impl
{
    public class RepositoryAsyncImpl<T> : IRepositoryAsync<T> where T : class
    {

        private readonly DataBaseContext _dataBaseContext;
        private bool _disposed = false;

        public RepositoryAsyncImpl(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<T> Delete(T entity)
        {
            EntitySet.Remove(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<T> DeleteById(int id)
        {
            T entity = await FindById(id);
            entity = await Delete(entity);
            return entity;
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!_disposed && dispose)
            {
                _dataBaseContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<T> Save(T entity)
        {
            EntitySet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            EntitySet.Update(entity);
            await SaveChanges();
            return entity;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _dataBaseContext.Set<T>();
            }
        }

        protected async Task SaveChanges()
        {
            await _dataBaseContext.SaveChangesAsync();
        }
    }
}
