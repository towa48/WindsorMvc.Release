// -----------------------------------------------------------------------
// <copyright file="MenuRepository.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using WindsorMvc.Web.DataAccess;
    using WindsorMvc.Framework.Utils;
    using WindsorMvc.Framework.Components.CustomMenu.Items;

    public class MenuRepository : IMenuRepository
    {
        private readonly IDataContextProvider _contextProvider; // save provider from GC
        private readonly CustomContext context;

        public MenuRepository(IDataContextProvider contextProvider)
        {
            ParamUtility.IsNotNull(contextProvider, "contextProvider");
            this._contextProvider = contextProvider;
            this.context = contextProvider.Context;
        }

        public IQueryable<MenuItem> All
        {
            get { return context.Menus; }
        }

        public IQueryable<MenuItem> AllIncluding(params Expression<Func<MenuItem, object>>[] includeProperties)
        {
            IQueryable<MenuItem> query = context.Menus;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public MenuItem Find(System.Guid id)
        {
            return context.Menus.Find(id);
        }

        public void InsertOrUpdate(MenuItem menu)
        {
            if (menu.ID == default(System.Guid)) {
                // New entity
                menu.ID = Guid.NewGuid();
                context.Menus.Add(menu);
            } else {
                // Existing entity
                context.Entry(menu).State = EntityState.Modified;
            }
        }

        public void Delete(System.Guid id)
        {
            var menu = context.Menus.Find(id);
            context.Menus.Remove(menu);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}