using Nik.Advanced.Business.Interface.Utility;
using System.Transactions;

namespace Nik.Advanced.Business.Service.Utility
{
    public class UnitOfWork : IUnitOfWork
    {
        TransactionScope trans = null;

        public UnitOfWork()
        {
            trans = new TransactionScope();
        }

        public void Commit()
        {
            if (trans != null)
            {
                trans.Complete();
            }
        }

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
            }
        }
    }
}
