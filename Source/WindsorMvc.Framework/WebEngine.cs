// -----------------------------------------------------------------------
// <copyright file="WebEngine.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Reflection;
    using Castle.Windsor;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel;
    using WindsorMvc.Framework.Mvc;
    using WindsorMvc.Framework.Utils;    

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public sealed class WebEngine: IEngine
    {
        private readonly IWindsorContainer _container;

        public WebEngine()
        {
            this._container = new WindsorContainer();
            // Register IEngine
            this._container.Register(Component.For(typeof(IEngine)).Instance(this));
            // Register IWindsorContainer
            this._container.Register(Component.For(typeof(IWindsorContainer)).Instance(this._container));
            // Register IKernel
            this._container.Register(Component.For(typeof(IKernel)).Instance(this._container.Kernel));
            // Register IControllerFactory
            this._container.Register(Component.For(typeof(IControllerFactory)).ImplementedBy(typeof(CustomControllerFactory)).LifeStyle.Transient);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <returns></returns>
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = CreateEngineInstance();
            }
            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <returns></returns>
        public static IEngine CreateEngineInstance()
        {
            return new WebEngine();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize();
                }
                return Singleton<IEngine>.Instance;
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterControllers(Assembly assembly)
        {
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (MvcUtility.IsController(type))
                {
                    this._container.Register(Component.For(type).Named(type.FullName.ToLower()).LifeStyle.Transient);
                }
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        internal IWindsorContainer Container
        {
            get { return this._container; }
        }

        public T Resolve<T>() where T : class
        {
            return (T)this._container.Resolve(typeof(T));
        }

        public T Resolve<T>(System.Collections.IDictionary arguments)
        {
            return (T)this._container.Resolve(typeof(T), arguments);
        }

        public object Resolve(Type serviceType)
        {
            return this._container.Resolve(serviceType);
        }
    }
}
