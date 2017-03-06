using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Nik.Advanced.Business.Interface
{
    public interface IBaseService : IDisposable
    {
        T Insert<T>(T t) where T : class;

        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        void Delete<T>(T t) where T : class;

        void Delete<T>(int id) where T : class;

        void Update<T>(T t) where T : class;

        void Update<T>(IEnumerable<T> tList) where T : class;

        T Find<T>(int id) where T : class;

        IQueryable<T> ExecuteQuery<T>(string sql, SqlParameter[] parms) where T : class;

        void Excute<T>(string sql, SqlParameter[] parms) where T : class;

        IQueryable<T> Set<T>() where T : class;
    }
}
