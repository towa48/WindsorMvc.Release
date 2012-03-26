// -----------------------------------------------------------------------
// <copyright file="CustomMenuRenderer.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Components.CustomMenu.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindsorMvc.Framework.Utils;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomMenuRenderer
    {
        private readonly CustomMenu _menu;
        private readonly HtmlHelper _helper;

        public CustomMenuRenderer(CustomMenu menu, HtmlHelper helper)
        {
            ParamUtility.IsNotNull(menu, "menu");
            ParamUtility.IsNotNull(helper, "helper");
            this._menu = menu;
            this._helper = helper;
        }

        public string GetLayout()
        {
            if (this._menu.Items.Count() > 0)
            {
                var sb = new StringBuilder();

                sb.AppendLine("<ul id=\"menu\">");
                foreach (var item in this._menu.Items)
                {
                    var rvd = new RouteValueDictionary(new { controller = item.ControllerShortName, action = item.ActionName });
                    string url = RouteTable.Routes.GetVirtualPath(this._helper.ViewContext.RequestContext, rvd).VirtualPath;
                    sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>{2}", url, item.Title, Environment.NewLine);
                }
                sb.AppendLine("</ul>");

                return sb.ToString();
            }

            return String.Empty;
        }
    }
}
