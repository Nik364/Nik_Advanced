using Nik.Advanced.Business.Interface;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace Nik.Advanced.Business.Service
{
    public class BaseService : IBaseService
    {
        //Context不应做成单例，也不应该每一次操作数据库都创建一个，而是每一次业务操作使用一个Context
        public DbContext Context { get; private set; }

        /// <summary>
        /// unity可通过三种方式实现注入：属性、方法、构造函数。
        /// 
        /// 利用构造函数实现ioc注入，此种方式可不显示指明，因此不依赖与具体的ioc容器，便于容器替换
        /// 默认选择参数最多的构造函数注入
        /// </summary>
        /// <param name="context"></param>
        public BaseService(DbContext context)
        {
            this.Context = context;
        }

        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.Context.Set<T>().AddRange(tList);
            //一个链接，多条insert语句分开执行
            this.Commit();
            return tList;
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null)
            {
                throw new Exception("t is null");
            }

            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);
            if (t == null)
            {
                throw new Exception("t is null");
            }
            this.Delete<T>(t);
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null)
            {
                throw new Exception("t is null");
            }

            /**
             * 更新分为两种情况：
             *  1、通过查询获取的实体，修改后更新。
             *  2、手动创建的实体更新，这种实体在上下文中不存在，需附加到上下文，将对象保存到本地之后才可更新。
             *  
             *  将数据附加到上下文，并重置为UnChanged，支持以上两种更新
             *  注：若先查询了一个实体，之后手动创建了一个主键一样的实体，执行Attach时会报错，因主键冲突
             */
            this.Context.Set<T>().Attach(t);
            this.Context.Entry<T>(t).State = EntityState.Modified;
            //保存，重置实体状态为UnChanged
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        public T Find<T>(int id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }

        public IQueryable<T> ExecuteQuery<T>(string sql, SqlParameter[] parms) where T : class
        {
            return this.Context.Database.SqlQuery<T>(sql, parms).AsQueryable();
        }

        public void Excute<T>(string sql, SqlParameter[] parms) where T : class
        {
            DbContextTransaction trans = null;
            try
            {
                trans = this.Context.Database.BeginTransaction();
                this.Context.Database.ExecuteSqlCommand(sql, parms);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        protected void Commit()
        {
            this.Context.SaveChanges();
        }

        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}
