using Nik.Advanced.Model;

namespace Nik.Advanced.Business.Interface
{
    public interface IUserMenuService : IBaseService
    {
        void DeleteMappingByMenu(Sys_Menu menu);
    }
}
