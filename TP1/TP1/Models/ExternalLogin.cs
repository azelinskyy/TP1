// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalLogin.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The users context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Models
{
    /// <summary>
    ///     The external login.
    /// </summary>
    public class ExternalLogin
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the provider.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        ///     Gets or sets the provider display name.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the provider user id.
        /// </summary>
        public string ProviderUserId { get; set; }

        #endregion
    }
}