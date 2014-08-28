// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidateHttpAntiForgeryTokenAttribute.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The validate http anti forgery token attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Helpers;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Web.Mvc;

    /// <summary>
    ///     The validate http anti forgery token attribute.
    /// </summary>
    public class ValidateHttpAntiForgeryTokenAttribute : AuthorizationFilterAttribute
    {
        #region Public Methods and Operators

        /// <summary>
        /// The on authorization.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpRequestMessage request = actionContext.ControllerContext.Request;

            try
            {
                if (this.IsAjaxRequest(request))
                {
                    this.ValidateRequestHeader(request);
                }
                else
                {
                    AntiForgery.Validate();
                }
            }
            catch (HttpAntiForgeryException e)
            {
                actionContext.Response = request.CreateErrorResponse(HttpStatusCode.Forbidden, e);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The is ajax request.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsAjaxRequest(HttpRequestMessage request)
        {
            IEnumerable<string> xrequestedWithHeaders;
            if (request.Headers.TryGetValues("X-Requested-With", out xrequestedWithHeaders))
            {
                string headerValue = xrequestedWithHeaders.FirstOrDefault();
                if (!string.IsNullOrEmpty(headerValue))
                {
                    return string.Equals(headerValue, "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
                }
            }

            return false;
        }

        /// <summary>
        /// The validate request header.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        private void ValidateRequestHeader(HttpRequestMessage request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;

            IEnumerable<string> tokenHeaders;
            if (request.Headers.TryGetValues("RequestVerificationToken", out tokenHeaders))
            {
                string tokenValue = tokenHeaders.FirstOrDefault();
                if (!string.IsNullOrEmpty(tokenValue))
                {
                    string[] tokens = tokenValue.Split(':');
                    if (tokens.Length == 2)
                    {
                        cookieToken = tokens[0].Trim();
                        formToken = tokens[1].Trim();
                    }
                }
            }

            AntiForgery.Validate(cookieToken, formToken);
        }

        #endregion
    }
}