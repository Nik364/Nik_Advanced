using Nik.Advanced.Business.Interface;
using Nik.Advanced.Model;
using System.Data.Entity;
using System.Linq;
using Nik.Advanced.Business.Service.Utility;

namespace Nik.Advanced.Business.Service
{
    public class CompanyService : BaseService, ICompanyService
    {
        private DbSet<Sys_Company> companyDbSet = null;

        public CompanyService(DbContext context)
            : base(context)
        {
            this.companyDbSet = context.Set<Sys_Company>();
        }

        public void UpdateCompany(Sys_Company company)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                base.Update<Sys_Company>(company);

                UserMenuService userMenu = new UserMenuService(base.Context);
                //ToList会结束延迟，直接到数据库执行sql
                var users = userMenu.Set<Sys_User>().Where(u => u.CompanyId.Equals(company.Id)).ToList();
                users.ForEach(u => u.CompanyName = company.Name);
                userMenu.Update<Sys_User>(users);

                unit.Commit();
            }
        }
    }
}
