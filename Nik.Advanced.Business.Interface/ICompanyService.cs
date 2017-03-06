using Nik.Advanced.Model;

namespace Nik.Advanced.Business.Interface
{
    public interface ICompanyService : IBaseService
    {
        void UpdateCompany(Sys_Company company);
    }
}
