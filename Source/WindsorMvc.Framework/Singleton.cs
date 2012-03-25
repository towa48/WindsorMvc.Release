// -----------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Singleton
    {
        static readonly IDictionary<Type, object> allSingletons;

        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : Singleton
    {
        static T instance;

        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
}
