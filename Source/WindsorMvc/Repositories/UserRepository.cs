// -----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WindsorMvc.Web.DataAccess;
    using WindsorMvc.Framework.Utils;

    public class UserRepository : IUserRepository
    {
        private readonly IDataContextProvider _contextProvider; // save from GC
        private readonly CustomContext context;

        public UserRepository(IDataContextProvider contextProvider)
        {
            ParamUtility.IsNotNull(contextProvider, "contextProvider");
            this._contextProvider = contextProvider;
            this.context = contextProvider.Context;
        }

        public bool UpdateLastActivity(string userName, DateTime dateTimeUtc)
        {
            // todo: update db
            return true;
        }
    }
}