﻿using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Nik.Advanced.Web.Core.IOC
{
    /// <summary>
    /// Unity容器工厂
    /// </summary>
    public class ContainerFactory
    {
        static object syncHelper = new object();
        static Dictionary<string, IUnityContainer> unityContainerCache = new Dictionary<string, IUnityContainer>();

        public static IUnityContainer CreateContainer(string name = "DefaultContainer")
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"CfgFiles\Unity.Config.xml");
            return CreateContainer(path, name);
        }

        public static IUnityContainer CreateContainer(string path, string name)
        {
            if (!unityContainerCache.ContainsKey(name))
            {
                //考虑到Web多线程模型下线程安全，此处应加锁
                lock (syncHelper)
                {
                    if (!unityContainerCache.ContainsKey(name))
                    {
                        //获取config
                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        fileMap.ExeConfigFilename = path;
                        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                        //配置Unity
                        IUnityContainer container = new UnityContainer();
                        section.Configure(container, name);

                        //缓存Container
                        unityContainerCache.Add(name, container);
                    }
                }
            }
            return unityContainerCache[name];
        }
    }
}
