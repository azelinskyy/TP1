// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthConfig.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The auth config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1
{
    /// <summary>
    ///     The auth config.
    /// </summary>
    public static class AuthConfig
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The register auth.
        /// </summary>
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            // OAuthWebSecurity.RegisterMicrosoftClient(
            // clientId: "",
            // clientSecret: "");

            // OAuthWebSecurity.RegisterTwitterClient(
            // consumerKey: "",
            // consumerSecret: "");

            // OAuthWebSecurity.RegisterFacebookClient(
            // appId: "",
            // appSecret: "");

            // OAuthWebSecurity.RegisterGoogleClient();
        }

        #endregion
    }
}