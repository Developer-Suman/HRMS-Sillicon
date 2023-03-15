using HRMS_Silicon.Repository.RepoImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_Silicon.Repository.RepoInterface
{
    public interface UnitOfWorkIRepo: IDisposable
    {
        int Commit();
        //int ExecWithStoreProcedure(string query, params object[] parameters);
        EntityDatabaseTransaction BeginTransaction();
    }
}

