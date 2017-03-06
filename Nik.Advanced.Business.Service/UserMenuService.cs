using Nik.Advanced.Business.Interface;
using System.Data.Entity;
using Nik.Advanced.Model;
using System.Linq;

namespace Nik.Advanced.Business.Service
{
    /// <summary>
    /// 用户、菜单服务
    /// 不需要为每一个数据库实体去建立一个独立的业务逻辑类，应类似DDD中的领域一样，按业务来建类，便于事务处理，同时减少DbContext
    /// </summary>
    public class UserMenuService : BaseService, IUserMenuService
    {
        DbSet<Sys_Menu> menuDbSet = null;
        DbSet<Sys_User> userDbSet = null;
        DbSet<Sys_UserMenuMapping> userMenuDbSet = null;

        public UserMenuService(DbContext context)
            : base(context)
        {
            this.menuDbSet = context.Set<Sys_Menu>();
            this.userDbSet = context.Set<Sys_User>();
            this.userMenuDbSet = context.Set<Sys_UserMenuMapping>();
        }

        public void DeleteMappingByMenu(Sys_Menu menu)
        {
            var menus = menuDbSet.Where(m => m.Path.StartsWith(menu.Path));
            var mappings = userMenuDbSet.Where(um => menus.Select(m => m.Id).Contains(um.MenuId.Value));
            userMenuDbSet.RemoveRange(mappings);
            menuDbSet.RemoveRange(menus);
            base.Commit();
        }
    }
}
