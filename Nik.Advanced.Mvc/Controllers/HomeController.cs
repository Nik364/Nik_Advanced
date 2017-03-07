using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Nik.Advanced.Business.Interface;
using Nik.Advanced.Web.Core.IOC;
using Nik.Advanced.Model;

namespace Nik.Advanced.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IUserMenuService userMenuService = null;
        public HomeController(IUserMenuService userMenuService)
        {
            this.userMenuService = userMenuService;
        }

        public ActionResult Index()
        {
            ViewBag.Tag = 10;

            //IUserMenuService userMenuService = ContainerFactory.CreateContainer().Resolve<IUserMenuService>();
            Sys_User user = userMenuService.Find<Sys_User>(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}