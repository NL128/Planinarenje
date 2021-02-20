using DBLibrary.DBContexts;
using DBLibrary.Models;
using Planinarenje.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Planinarenje
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IDBAccess,DBEntityFramework>();
            //container.RegisterType<IDBCountryArea, DBEntityFrameworkCountryArea>();
            //container.RegisterType<IDBEvents, DBEntityFrameworkEvents>();
            container.RegisterType<IDBInheritAccessCountryEvents, DBInheritAccessCountryEvents>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}