// -----------------------------------------------------------------------
// <copyright file="MvcUtility.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class MvcUtility
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsController(Type type)
        {
            return type != null
                   && !type.IsAbstract
                   && typeof(IController).IsAssignableFrom(type);
        }
    }
}
