// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1
{
    using System.Web.Optimization;

    /// <summary>
    ///     The bundle config.
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        #region Public Methods and Operators

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"));

            bundles.Add(
                new ScriptBundle("~/bundles/knockout").Include(
                    "~/Scripts/knockout-{version}.js",
                    "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxlogin").Include("~/Scripts/app/ajaxlogin.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/Internationalization").Include(
                    "~/Scripts/Internationalization/base.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/tools").Include(
                    "~/Scripts/tools/binders.datepicker.js",
                    "~/Scripts/tools/spinner.js",
                    "~/Scripts/tools/grid.base.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/report").Include(
                    "~/Scripts/app/report.js",
                    "~/Scripts/app/project.model.js",
                    "~/Scripts/app/project.viewmodel.js",
                    "~/Scripts/app/project.datacontext.js",
                    "~/Scripts/app/project.unselectedProjectsModel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            bundles.Add(
                new StyleBundle("~/Content/themes/base/css").Include(
                    "~/Content/themes/base/core.css",
                    "~/Content/themes/base/resizable.css",
                    "~/Content/themes/base/selectable.css",
                    "~/Content/themes/base/accordion.css",
                    "~/Content/themes/base/autocomplete.css",
                    "~/Content/themes/base/button.css",
                    "~/Content/themes/base/dialog.css",
                    "~/Content/themes/base/slider.css",
                    "~/Content/themes/base/tabs.css",
                    "~/Content/themes/base/datepicker.css",
                    "~/Content/themes/base/progressbar.css",
                    "~/Content/themes/base/theme.css"));

            bundles.Add(
                new StyleBundle("~/Content/bootstrap").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-theme.css"));
        }

        #endregion
    }
}