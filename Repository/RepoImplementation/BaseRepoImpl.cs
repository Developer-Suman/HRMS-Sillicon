using HRMS_Silicon.Data;
using HRMS_Silicon.Repository.RepoInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRMS_Silicon.Repository.RepoImplementation
{
    public class BaseRepoImpl<T> : BaseIRepo<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> _dbset;


        public BaseRepoImpl(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbset = applicationDbContext.Set<T>();

        }

        public void AddRange(IEnumerable<T> entities)
        {
            _applicationDbContext.Set<T>().AddRange(entities);
        }

        public void delete(T entity)
        {
            _dbset.Remove(entity);

            //var dbset = _applicationDbContext.Set<T>().Remove(entity);
            //_applicationDbContext.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _applicationDbContext.Set<T>().Where(expression);
        }

        public List<T> getAll()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        public T getById(int id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public IQueryable<T> getQueryable()
        {
            return _applicationDbContext.Set<T>();
        }

        public void insert(T entity)
        {
            _dbset.Add(entity);

            //var dbset = _applicationDbContext.Set<T>().Add(entity);
            //_applicationDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _applicationDbContext.Set<T>().RemoveRange(entities);
        }

        public void update(T entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Attach(T entity)
        {
            _dbset.Attach(entity);
        }
        public IQueryable<T> Queryable()
        {
            return _dbset.AsQueryable();
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

    }
}
