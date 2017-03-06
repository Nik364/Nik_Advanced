using System;

namespace Nik.Advanced.Business.Interface.Utility
{
    /// <summary>
    /// 实现多DbContext事务，可实现分布式事务
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
