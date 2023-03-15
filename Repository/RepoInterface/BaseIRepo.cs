using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRMS_Silicon.Repository.RepoInterface
{
    public interface BaseIRepo<T> where T : class
    {
        void Attach(T entity);
        IQueryable<T> Queryable();


        //Removes a record from the context
        void delete(T entity);

        //Adds a new record to the context
        void insert(T entity);
        
        void update(T entity);
        
        //Get’s all the Record.
        List<T> getAll();
        
        
        //Get’s the entity By Id.
        T getById(int id);
        
        IQueryable<T> getQueryable();
        
        
        //Finds a set of record that matches the passed expression.
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        //Add a list of records
        void AddRange(IEnumerable<T> entities);
        
        //Removes a list of records.
        void RemoveRange(IEnumerable<T> entities);
        
        void Save();
          

    }
}
