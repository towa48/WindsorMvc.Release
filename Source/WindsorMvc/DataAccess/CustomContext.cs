// -----------------------------------------------------------------------
// <copyright file="CustomContext.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using WindsorMvc.Framework.Components.CustomMenu.Items;

    public class CustomContext: DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WindsorMvc.Web.Models.CustomContext>());

        public CustomContext()
        {
            this.Menus = new FakeDbSet<MenuItem>();
            this.Menus.Add(new MenuItem() { ID = Guid.Parse("0bf1baae-3654-41cf-9460-1ceff3855fce"), Title = "Home", ControllerShortName = "Home", ActionName = "Index" });
            this.Menus.Add(new MenuItem() { ID = Guid.Parse("e00de6ba-80e4-495e-b4f9-7ff8c8e5c990"), Title = "About", ControllerShortName = "Home", ActionName = "About" });
        }

        public IDbSet<MenuItem> Menus { get; set; }
    }
}