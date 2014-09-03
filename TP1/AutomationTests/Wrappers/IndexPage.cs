// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexPage.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The index page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutomationTests.Wrappers
{
    using AutomationTests.Infrastructure;

    using OpenQA.Selenium;

    /// <summary>
    /// The index page.
    /// </summary>
    public class IndexPage : BasePage
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        public IndexPage(IWebDriver driver)
            : base(driver)
        {
        }

        #endregion
    }
}