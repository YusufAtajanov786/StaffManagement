using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepo<T> : IBaseContract<T> where T : class
    {
        private readonly RepoContext _repoContext;

        public BaseRepo(RepoContext repoContext)
        {
            this._repoContext = repoContext;
        }
        public T Create(T entity)
        {
            _repoContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _repoContext.Set<T>().Remove(entity);
        }

        public virtual T Get(int id)
        {
            return _repoContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repoContext.Set<T>();
        }

     
        public void Update(T entiry)
        {
            var entity = _repoContext.Set<T>().Attach(entiry);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
        }
    }
}
