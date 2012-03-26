// -----------------------------------------------------------------------
// <copyright file="HtmlHelperExtensions.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using WindsorMvc.Framework.Components.CustomMenu;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        public static CustomMenuBuilder MainMenu(this HtmlHelper htmlHelper)
        {
            return new CustomMenuBuilder(htmlHelper);
        }

        public static IEngine GetEngine(this HtmlHelper htmlHelper)
        {
            // singleton
            return WebEngine.Current;
        }
    }
}
