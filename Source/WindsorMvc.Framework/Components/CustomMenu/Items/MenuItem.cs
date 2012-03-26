// -----------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Framework.Components.CustomMenu.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MenuItem
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string ControllerShortName { get; set; }
        public string ActionName { get; set; }
        public bool IsActive { get; set; }
    }
}
