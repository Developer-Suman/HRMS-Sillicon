using HRMS_Silicon.Data;
using HRMS_Silicon.Repository.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Repository.RepoImplementation
{
    public class UnitOfWorkRepoImpl : UnitOfWorkIRepo, IDisposable
    {
        private ApplicationDbContext entities = null;
        public UnitOfWorkRepoImpl(ApplicationDbContext applicationDbContext)
        {
            entities = applicationDbContext;
        }


        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public BaseIRepo<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as BaseIRepo<T>;
              
            }
            BaseIRepo<T> repo = new BaseRepoImpl<T>(entities);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public EntityDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(entities); 
        }

        public int Commit()
        {
            return entities.SaveChanges();
            //try
            //{
            //    return entities.SaveChanges();

            //}
            //catch(Exception ex)
            //{
            //    //TempData["Error"] = ex.Message;

            //    Console.WriteLine(ex.Message);
            //    throw;


            //}


        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                entities.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public int ExecWithStoreProcedure(string query, params object[] parameters)
        //{
        //    return entities.Database.ExecuteSqlCommand("EXEC " + query, parameters);
        //}
    }
}
