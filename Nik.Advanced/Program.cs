using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Nik.Advanced.Business.Interface;
using Nik.Advanced.Common.Unity;
using Nik.Advanced.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Nik.Advanced
{
    class Program
    {
        public static object IUser { get; private set; }

        static void Main(string[] args)
        {
            using (IUnityContainer container = UnityContainerFactory.CreateContainer("NikDbContainer"))
            using (IUserMenuService userService = container.Resolve<IUserMenuService>())
            {
                Sys_User user = userService.Find<Sys_User>(1);

                //IList<Sys_User> list = new List<Sys_User>
                //{
                //    new Sys_User { Name="李四"},
                //    new Sys_User { Name="王五"},
                //    new Sys_User { Name="赵六"}
                //};
                //userService.Insert<Sys_User>(list);
            }

             


            //Single a = new Single();

            //Type t = typeof(Single);

            //ConstructorInfo[] ctors = t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic| BindingFlags.Instance);

            //Single s = new Single();

        }


        class Single
        {
            private static Single s = null;

            //private Single()
            //{ }

            //static Single()
            //{
            //    s = new Single();
            //}


            public static Single CreateInstance()
            {
                return null;
            }
        }
    }
}
