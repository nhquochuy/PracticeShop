using Autofac;
using Autofac.Integration.Mvc;
using PracticeShop.Data.Models;
using PracticeShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeShop.Web
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlUserData>().As<IUserData>().InstancePerRequest();
            builder.RegisterType<SqlProductData>().As<IProduct>().InstancePerRequest();
            builder.RegisterType<PracticeShopDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}