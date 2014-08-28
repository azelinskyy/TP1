// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitializeSimpleMembershipAttribute.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The initialize simple membership attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Filters
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading;
    using System.Web.Mvc;

    using Infrastructure.Contexts;

    using WebMatrix.WebData;

    /// <summary>
    ///     The initialize simple membership attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        #region Static Fields

        /// <summary>
        ///     The initializer.
        /// </summary>
        private static SimpleMembershipInitializer initializer;

        /// <summary>
        ///     The initializer lock.
        /// </summary>
        private static object initializerLock = new object();

        /// <summary>
        ///     The is initialized.
        /// </summary>
        private static bool isInitialized;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref initializer, ref isInitialized, ref initializerLock);
        }

        #endregion

        /// <summary>
        ///     The simple membership initializer.
        /// </summary>
        private class SimpleMembershipInitializer
        {
            #region Constructors and Destructors

            /// <summary>
            ///     Initializes a new instance of the <see cref="SimpleMembershipInitializer" /> class.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// </exception>
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection(
                        "DefaultConnection", 
                        "UserProfile", 
                        "UserId", 
                        "UserName", 
                        true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        "The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", 
                        ex);
                }
            }

            #endregion
        }
    }
}