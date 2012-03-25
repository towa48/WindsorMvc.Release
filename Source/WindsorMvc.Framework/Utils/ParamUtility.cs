// -----------------------------------------------------------------------
// <copyright file="ParamUtility.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Helper class for argument validation.
    /// </summary>
    public static class ParamUtility
    {
        /// <summary>
        /// Ensures the specified argument is not null.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        public static void IsNotNull(object parameter, String parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, String.Format("Parameter {0} cannot be null.", parameterName));
            }
        }

        /// <summary>
        /// Ensures the specified string is not blank.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        public static void IsNotNullOrEmpty(String parameter, String parameterName)
        {
            if (string.IsNullOrEmpty((parameter ?? String.Empty)))
            {
                throw new ArgumentException(String.Format("Parameter {0} cannot be null or empty.", parameterName), parameterName);
            }
        }
    }
}
