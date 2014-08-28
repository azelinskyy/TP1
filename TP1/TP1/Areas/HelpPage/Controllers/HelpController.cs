// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpController.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The controller that will handle requests for the help page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TP1.Areas.HelpPage.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Mvc;

    using TP1.Areas.HelpPage.Models;

    /// <summary>
    ///     The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpController"/> class.
        /// </summary>
        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpController"/> class.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public HelpController(HttpConfiguration config)
        {
            this.Configuration = config;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public HttpConfiguration Configuration { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The api.
        /// </summary>
        /// <param name="apiId">
        /// The api id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Api(string apiId)
        {
            if (!string.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = this.Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return this.View(apiModel);
                }
            }

            return this.View("Error");
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        #endregion
    }
}