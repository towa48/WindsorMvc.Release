// -----------------------------------------------------------------------
// <copyright file="DataContextProvider.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class DataContextProvider : IDataContextProvider, IDisposable
    {
        private readonly CustomContext _context;

        public DataContextProvider()
        {
            this._context = new CustomContext();
        }

        public CustomContext Context
        {
            get { return this._context; }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}