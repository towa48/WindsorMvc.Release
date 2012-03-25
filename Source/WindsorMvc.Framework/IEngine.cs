// -----------------------------------------------------------------------
// <copyright file="IEngine.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IEngine
    {
        void RegisterControllers(Assembly assembly);
        T Resolve<T>() where T : class;
        T Resolve<T>(System.Collections.IDictionary arguments);
        object Resolve(Type serviceType);

        /// <summary>
        /// Release component instance
        /// </summary>
        /// <param name="service"></param>
        void Release(object instance);
    }
}
