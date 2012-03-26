// -----------------------------------------------------------------------
// <copyright file="CustomMenu.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Components.CustomMenu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindsorMvc.Framework.Components.CustomMenu.Items;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomMenu
    {
        public CustomMenu():
            this(new List<MenuItem>())
        {
        }

        public CustomMenu(IEnumerable<MenuItem> items)
        {
            this.Items = items;
        }

        public IEnumerable<MenuItem> Items { get; set; }
    }
}
