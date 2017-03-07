using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace Nik.Advanced.Web.Core.IOC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer UnityContniner
        {
            get { return ContainerFactory.CreateContainer(); }
        }

        /// <summary>
        /// 创建控制器对象
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            //注入控制器
            return (IController)this.UnityContniner.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            //释放对象
            this.UnityContniner.Teardown(controller);
        }
    }
}
