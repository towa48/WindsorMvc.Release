// -----------------------------------------------------------------------
// <copyright file="IMenuRepository.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using WindsorMvc.Framework.Components.CustomMenu.Items;
    
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IMenuRepository
    {
        IQueryable<MenuItem> All { get; }
        IQueryable<MenuItem> AllIncluding(params Expression<Func<MenuItem, object>>[] includeProperties);
        MenuItem Find(System.Guid id);
        void InsertOrUpdate(MenuItem menu);
        void Delete(System.Guid id);
        void Save();
    }
}
