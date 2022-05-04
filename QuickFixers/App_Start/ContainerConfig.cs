using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using QuickFixers.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace QuickFixers.App_Start
{
    public class ContainerConfig
    {

        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            // Autofac api
            var builder = new ContainerBuilder();

            // registering all controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryScheduledServiceData>()
                   .As<IServices>()
                   .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}