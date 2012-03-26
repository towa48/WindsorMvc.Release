// -----------------------------------------------------------------------
// <copyright file="UpdateActivityAttribute.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using WindsorMvc.Framework;
    using WindsorMvc.Web.Repositories;

    /// <summary>
    /// Action filter for updating last activity
    /// </summary>
    /// <example>
    /// GlobalFilters.Filters.Add(new UpdateActivityAttribute(engine));
    /// </example>
    public class UpdateActivityAttribute : ActionFilterAttribute
    {
        public UpdateActivityAttribute(IEngine engine)
        {
            this.Engine = engine ?? WebEngine.Current;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.RequestContext.HttpContext.User;
            //if (user.Identity.IsAuthenticated)
            //{
                UpdateLastActivity(user); // Update last activity
            //}
        }

        #region Public properties

        public IEngine Engine { get; set; }

        #endregion

        #region Private methods

        private void UpdateLastActivity(System.Security.Principal.IPrincipal user)
        {
            //if (user != null && user.Identity.IsAuthenticated)
            //{
                var userRepository = Engine.Resolve<IUserRepository>();
                userRepository.UpdateLastActivity(user.Identity.Name, DateTime.UtcNow);
                Engine.Release(userRepository);
            //}
        }

        #endregion
    }
}
