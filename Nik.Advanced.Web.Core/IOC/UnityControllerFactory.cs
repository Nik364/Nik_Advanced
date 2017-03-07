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

            /*
             * 注入控制器
             * 
             * Resolve传入具体的实例，unity不需要动态反射实例化对象，因此不需要提前配置对象关系映射。
             * 主要作用将controllerType.GetType()类型中的对象注入外部资源
             */
            return (IController)this.UnityContniner.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            //释放对象
            this.UnityContniner.Teardown(controller);
        }
    }
}
