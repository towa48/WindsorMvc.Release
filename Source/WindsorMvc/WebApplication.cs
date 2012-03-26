// -----------------------------------------------------------------------
// <copyright file="WebApplication.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;
    using WindsorMvc.Framework;
    using Castle.MicroKernel;
    using WindsorMvc.Web.DataAccess;
    using WindsorMvc.Web.Repositories;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class WebApplication
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="filters"></param>
        public void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="routes"></param>
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        /// <summary>
        /// Register main application components
        /// </summary>
        /// <param name="engine"></param>
        public void RegisterComponents(IEngine engine)
        {
            var kernel = engine.Resolve<IKernel>();

            // Register Singleton Components
            kernel.Register(Castle.MicroKernel.Registration.Component.For<IDataContextProvider>().ImplementedBy<DataContextProvider>().LifeStyle.PerWebRequest);
            kernel.Register(Castle.MicroKernel.Registration.Component.For<IMenuRepository>().ImplementedBy<MenuRepository>().LifeStyle.Transient);
        }
    }
}
