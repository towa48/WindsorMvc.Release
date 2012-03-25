// -----------------------------------------------------------------------
// <copyright file="CustomControllerFactory.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Routing;
    using System.Web.Mvc;
    using Castle.MicroKernel;
    using WindsorMvc.Framework.Utils;
    
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomControllerFactory: DefaultControllerFactory
    {
        private readonly IEngine _engine;

        public CustomControllerFactory(IEngine engine)
        {
            ParamUtility.IsNotNull(engine, "engine");
            this._engine = engine;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;
            if (controllerType == null)
            {
                throw new HttpException(404, String.Format("The controller for path '{0}' could not be found or it does not implement IController.", requestContext.HttpContext.Request.Path));
            }
            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException(String.Format("Type requested is not a controller: {0}", controllerType.Name), "controllerType");
            }

            try
            {
                controller = this._engine.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Error resolving controller {0}", controllerType.Name), ex);
            }

            return controller;
        }

        public IControllerFactory ControllerFactory
        {
            get { return this; }
        }

        #region Methods for DEBUG purposes

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return base.CreateController(requestContext, controllerName);
        }
        
        public new Type GetControllerType(RequestContext context, String controllerName)
        {
            return base.GetControllerType(context, controllerName);
        }

        #endregion
    }
}
