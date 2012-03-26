// -----------------------------------------------------------------------
// <copyright file="CustomMenuBuilder.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Components.CustomMenu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindsorMvc.Framework.Utils;
    using System.Web.Mvc;
    using WindsorMvc.Framework.Components.CustomMenu.Items;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomMenuBuilder : IBuilder
    {
        private HtmlHelper _helper;
        private IQueryable<MenuItem> _query;

        public CustomMenuBuilder(HtmlHelper helper)
        {
            ParamUtility.IsNotNull(helper, "helper");
            this._helper = helper;
            this.Menu = new CustomMenu();
        }

        #region Public properties

        public CustomMenu Menu { get; private set; }

        #endregion

        #region Public methods

        public CustomMenuBuilder SetSource(IQueryable<MenuItem> query)
        {
            this._query = query;
            return this;
        }

        /// <summary>
        /// Method for generating control layout
        /// </summary>
        /// <returns>Control layout</returns>
        public MvcHtmlString RenderControl()
        {
            var list = this._query.ToList();
            this.Menu.Items = this.Menu.Items.Concat(list);
            // create renderer
            var renderer = new Html.CustomMenuRenderer(this.Menu, this._helper);
            return new MvcHtmlString(renderer.GetLayout());
        }

        #endregion
    }
}
