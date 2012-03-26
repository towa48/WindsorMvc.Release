// -----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using WindsorMvc.Framework;
    using System.Reflection;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            var engine = this.Engine; // Initialize CMS engine
            engine.RegisterControllers(Assembly.GetExecutingAssembly());

            var app = new WebApplication();
            app.RegisterGlobalFilters(GlobalFilters.Filters);
            app.RegisterRoutes(RouteTable.Routes);
            app.RegisterComponents(engine);

            // Register custom controller factory
            ControllerBuilder.Current.SetControllerFactory(engine.Resolve<IControllerFactory>());
        }

        private IEngine _engine;
        public IEngine Engine
        {
            get
            {
                return _engine ??
                    (_engine = WebEngine.Current);
            }
            set { _engine = value; }
        }
    }
}