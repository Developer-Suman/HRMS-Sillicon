using HRMS_Silicon.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Repository.RepoImplementation
{
    public class EntityDatabaseTransaction : IDisposable
    {
        private IDbContextTransaction _transaction;
        public EntityDatabaseTransaction(ApplicationDbContext applicationDbContext)
        {
            _transaction = applicationDbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
