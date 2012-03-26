// -----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WindsorMvc.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IUserRepository
    {
        bool UpdateLastActivity(string userName, DateTime dateTimeUtc);
    }
}
