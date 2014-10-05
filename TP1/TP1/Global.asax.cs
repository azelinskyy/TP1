// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The mvc application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1
{
    using System.Globalization;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Infrastructure.Contexts;

    using Newtonsoft.Json;

    using Resources;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    ///     The mvc application.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        ///     The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            this.GenerateLanguageFiles();

            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DomainContext>());
        }

        private void GenerateLanguageFiles()
        {
            var resourceService = new LocalizationService();
            System.IO.File.WriteAllText(this.Server.MapPath("~/Scripts/Internationalization/ua.js"), JsonConvert.SerializeObject(ConvertToJson.ConvertResourceToDictionary(resourceService.Manager, new CultureInfo("uk-UA"))));
            System.IO.File.WriteAllText(this.Server.MapPath("~/Scripts/Internationalization/en.js"), JsonConvert.SerializeObject(ConvertToJson.ConvertResourceToDictionary(resourceService.Manager, CultureInfo.CurrentCulture)));
            System.IO.File.WriteAllText(this.Server.MapPath("~/Scripts/Internationalization/de.js"), JsonConvert.SerializeObject(ConvertToJson.ConvertResourceToDictionary(resourceService.Manager, new CultureInfo("de-DE"))));
        }

        #endregion
    }
}